using System;
using Unity.Netcode;

namespace Rumi.LCNetworks.API
{
    /// <summary>
    /// Any class that inherits from this class will automatically be instantiated and registered during the <see cref="LCNHPlugin.Awake"/> phase.<br/>
    /// However, there must be a constructor without arguments (regardless of access modifiers)
    /// <br/><br/>
    /// 이 클래스를 상속하고 있는 모든 클래스는 <see cref="LCNHPlugin.Awake"/> 단계에 자동으로 인스턴스가 생성 및 등록됩니다<br/>
    /// 단, 인수 없는 생성자가 무조건 있어야합니다 (접근 제한자 상관 X)
    /// </summary>
    public abstract class LCNHNetworkBehaviour : NetworkBehaviour
    {
        /// <summary>
        /// The name of the handler.
        /// <br/><br/>
        /// 핸들러의 이름입니다.
        /// </summary>
        public new abstract string name { get; }

        /// <summary>
        /// This is the hash value of this class, and it must be **unconditionally** the same across the global network.<br/>
        /// So, set it to a random constant so that it does not overlap.
        /// <br/><br/>
        /// 이 클래스의 해시 값이며, 글로벌 네트워크 전반에서 **무조건적으로** 동일해야 합니다.<br/>
        /// 따라서 겹치지 않도록 무작위 상수로 설정하세요.
        /// </summary>
        public abstract uint globalIdHash { get; }
    }
}
