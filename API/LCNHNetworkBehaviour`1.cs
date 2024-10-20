using Unity.Netcode;

namespace Rumi.LCNetworks.API
{
    /// <summary>
    /// A singleton version of the <see cref="LCNHNetworkBehaviour"/> class.
    /// <br/><br/>
    /// Any class that inherits from this class will automatically be instantiated and registered during the <see cref="LCNHPlugin.Awake"/> phase.<br/>
    /// However, there must be a constructor without arguments (regardless of access modifiers)
    /// <br/><br/>-------------------------------<br/><br/>
    /// <see cref="LCNHNetworkBehaviour"/> 클래스의 싱글톤 버전입니다.
    /// <br/><br/>
    /// 이 클래스를 상속하고 있는 모든 클래스는 <see cref="LCNHPlugin.Awake"/> 단계에 자동으로 인스턴스가 생성 및 등록됩니다<br/>
    /// 단, 인수 없는 생성자가 무조건 있어야합니다 (접근 제한자 상관 X)
    /// </summary>
    public abstract class LCNHNetworkBehaviour<T> : LCNHNetworkBehaviour where T : LCNHNetworkBehaviour<T>
    {
        /// <summary>
        /// An instance of a handler.
        /// <br/><br/>
        /// 핸들러의 인스턴스입니다.
        /// </summary>
        public static T? instance { get; private set; }



        /// <summary>
        /// A method that is automatically called when the handler is spawned.<br/>
        /// If you don't know exactly what you are doing, don't call this method.
        /// <br/><br/>
        /// 핸들러가 스폰될 때 자동 호출되는 메소드입니다.<br/>
        /// 자신이 무엇을 하고 있는지 정확하게 모른다면, 이 메소드를 호출하지 마세요.
        /// </summary>
        public override void OnNetworkSpawn()
        {
            if (IsServer && instance != null)
                instance.gameObject.GetComponent<NetworkObject>().Despawn();

            instance = (T?)this;
        }

        /// <summary>
        /// A method that is automatically called when the handler is despawned.
        /// If you don't know exactly what you are doing, don't call this method.
        /// <br/><br/>
        /// 핸들러가 디스폰 될 때 자동으로 호출되는 메소드입니다.<br/>
        /// 자신이 무엇을 하고 있는지 정확하게 모른다면, 이 메소드를 호출하지 마세요.
        /// </summary>
        public override void OnNetworkDespawn() => instance = null;
    }
}
