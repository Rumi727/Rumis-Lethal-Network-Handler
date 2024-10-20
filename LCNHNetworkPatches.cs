using HarmonyLib;
using Rumi.LCNetworks.API;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace Rumi.LCNetworks
{
    /// <summary>
    /// Responsible for network patching in LCNA mod.<br/>
    /// Patch the <see cref="GameNetworkManager.Start"/> and <see cref="StartOfRound.Awake"/> methods to allow creating network handler objects.
    /// <br/><br/>
    /// LCNA 모드의 네트워크 패치를 담당합니다.<br/>
    /// 네트워크 핸들러 오브젝트를 생성할 수 있게 <see cref="GameNetworkManager.Start"/> 메소드와 <see cref="StartOfRound.Awake"/> 메소드를 패치합니다.<br/>
    /// </summary>
    public static class LCNHNetworkPatches
    {
        /// <summary>패치합니다</summary>
        public static void Patch()
        {
            Debug.Log($"{nameof(GameNetworkManager)} Patch...");

            try
            {
                LCNHPlugin.harmony.PatchAll(typeof(LCNHNetworkPatches));
                Debug.Log($"{nameof(GameNetworkManager)} Patched!");
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
                Debug.Log($"{nameof(GameNetworkManager)} Patch Fail!");
            }
        }



        static readonly List<(NetworkObject networkObject, string name)> networkObjects = new();

        [HarmonyPatch(typeof(GameNetworkManager), nameof(GameNetworkManager.Start))]
        [HarmonyPostfix]
        static void GameNetworkManager_Start_Postfix()
        {
            for (int i = 0; i < ReflectionManager.networks.Count; i++)
            {
                System.Type type = ReflectionManager.networks[i];

                try
                {
                    GameObject gameObject = new GameObject("LCNA Network Handler");
                    NetworkObject networkObject = gameObject.AddComponent<NetworkObject>();
                    LCNHNetworkBehaviour behaviour = (LCNHNetworkBehaviour)gameObject.AddComponent(type);

                    gameObject.name = behaviour.name;
                    gameObject.gameObject.hideFlags = HideFlags.HideAndDontSave;

                    networkObject.GlobalObjectIdHash = behaviour.globalIdHash;

                    networkObject.SynchronizeTransform = false;
                    networkObject.AutoObjectParentSync = false;

                    NetworkManager.Singleton.AddNetworkPrefab(gameObject);

                    networkObjects.Add((networkObject, behaviour.name));
                }
                catch (System.Exception e)
                {
                    Debug.LogError(e);
                }
            }
        }

        [HarmonyPatch(typeof(StartOfRound), nameof(StartOfRound.Awake))]
        [HarmonyPostfix]
        static void StartOfRound_Awake_Postfix()
        {
            if (networkObjects == null || !NetworkManager.Singleton.IsHost && !NetworkManager.Singleton.IsServer)
                return;

            for (int i = 0; i < networkObjects.Count; i++)
            {
                try
                {
                    (NetworkObject networkObject, string name) = networkObjects[i];
                    NetworkObject clonedObject = Object.Instantiate(networkObject);

                    clonedObject.name = name;
                    clonedObject.Spawn();
                }
                catch (System.Exception e)
                {
                    Debug.LogError(e);
                }
            }
        }
    }
}
