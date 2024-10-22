# Rumi's Lethal Network Handler

## English

[LCNHNetworkBehaviour&lt;T&gt;]: https://github.com/Rumi727/Rumis-Lethal-Network-Handler/blob/main/API/LCNHNetworkBehaviour%601.cs
[Wiki]: https://lethal.wiki/dev/advanced/networking#creating-the-networkhandler
[LCNHPlugin]: https://github.com/Rumi727/Rumis-Lethal-Network-Handler/blob/main/LCNHPlugin.cs

[Modding Wiki's Network section][Wiki] When creating a singleton network handler, did you find it annoying to use prefabs, patch lethal, and create objects?

I was also annoyed \
So I created this library

If you inherit the [LCNHNetworkBehaviour&lt;T&gt;] class of this mod, it will handle everything for you. (Note that T must be its self class)\
Even creating objects!
\
\
\
This mod only automatically handles the [Creating the NetworkHandler][wiki] part,\
so you have to do the rest yourself.

However, ![alt text](https://github.com/Rumi727/Rumis-Lethal-Network-Handler/raw/main/image.png) the ``NetcodePatcher`` method in this part is in the [LCNHPlugin] class.\
If you don't want to bother creating a method, use the method in that plugin.

### Note

The [LCNHNetworkBehaviour&lt;T&gt;] class is an abstract class, and has two properties that must be implemented.

* name : The name of the handler.
* globalIdHash : \
The hash value of this class, which must be **unconditionally** the same across the global network.\
Therefore, set it to a random constant to avoid overlapping.

### Note 2

Actually, this is my first time using a network, so I may not need this...  Please understand.\
I actually made this for my own use.

## 한국어

[모딩 위키의 네트워크 문단][Wiki]에서 싱글톤 네트워크 핸들러를 생성할 때, 프리팹을 사용하고 리썰을 패치하고 오브젝트를 생성하는게 귀찮으셨나요?

저도 귀찮았습니다\
그래서 이 라이브러리를 만들었어요

이 모드의 [LCNHNetworkBehaviour&lt;T&gt;] 클래스를 상속하면, 알아서 모든것을 다 처리해줍니다 (단, T는 자기 자신이여야합니다)\
심지어 오브젝트 생성까지도요!
\
\
\
[Creating the NetworkHandler][wiki] 부분 만 자동으로 처리해주는 모드이기 때문에\
나머지는 직접 하셔야합니다

다만 ![alt text](https://github.com/Rumi727/Rumis-Lethal-Network-Handler/raw/main/image.png) 이 부분의 ``NetcodePatcher`` 메소드는 [LCNHPlugin] 클래스에 있습니다\
메소드를 만드는게 귀찮다면 이 모드의 메소드를 사용하세요

### 참고 사항

[LCNHNetworkBehaviour&lt;T&gt;] 클래스는 추상 클래스이고,\
구현해야할 프로퍼티가 2개 존재합니다

* name : 핸들러의 이름입니다.
* globalIdHash : \
이 클래스의 해시 값이며, 글로벌 네트워크 전반에서  **무조건적으로** 동일해야 합니다.\
따라서 겹치지 않도록 무작위 상수로 설정하세요.

### 참고 사항 2

사실 네트워크 처음 만져보는거라 이런게 필요 없을 수도 있습니다만... 이해해주세요\
사실 제가 쓰려고 만든거거든요
