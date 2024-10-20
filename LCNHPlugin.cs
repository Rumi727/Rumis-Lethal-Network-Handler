using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Reflection;
using System;
using UnityEngine;

namespace Rumi.LCNetworks
{
    /// <summary>
    /// This is the main class for the Lethal Company Network API mode.
    /// <br/><br/>
    /// Rumi's Lethal Company Network Handler 모드의 메인 클래스입니다
    /// </summary>
    [BepInPlugin(modGuid, modName, modVersion)]
    public sealed class LCNHPlugin : BaseUnityPlugin
    {
        /// <summary>GUID of this mod<br/><br/>이 모드의 GUID</summary>
        public const string modGuid = "Rumi.LCNetworkHandler";

        /// <summary>Name of this mod<br/><br/>이 모드의 이름</summary>
        public const string modName = "LCNetworkHandler";

        /// <summary>Version of this mod<br/><br/>이 모드의 버전</summary>
        public const string modVersion = "1.0.0";

        internal static ManualLogSource? logger { get; private set; } = null;

        internal static Harmony harmony { get; } = new Harmony(modGuid);

        void Awake()
        {
            logger = Logger;

            Debug.Log("Start loading plugin...");

            LCNHNetworkPatches.Patch();

            Debug.Log($"Plugin {modName} is loaded!");
        }



        /// <summary>
        /// Calls all methods in the current assembly that have the <see cref="RuntimeInitializeOnLoadMethodAttribute"/> attribute.
        /// <br/><br/>
        /// <see cref="RuntimeInitializeOnLoadMethodAttribute"/> 어트리뷰트가 붙어있는 현재 어셈블리의 모든 메소드를 호출합니다.
        /// </summary>
        public static void NetcodePatcher()
        {
            Type[] types = Assembly.GetCallingAssembly().GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                Type? type = types[i];
                MethodInfo[] methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

                for (int j = 0; j < methods.Length; j++)
                {
                    MethodInfo? method = methods[j];
                    object[] attributes = method.GetCustomAttributes(typeof(RuntimeInitializeOnLoadMethodAttribute), false);

                    if (attributes.Length > 0)
                        method.Invoke(null, null);
                }
            }
        }
    }
}
