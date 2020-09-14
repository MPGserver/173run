using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace scp173run
{
    public class Config : IConfig
    {
        [Description("플러그인을 활성화 할까요? (이벤트 종료시 true를 false로 하시면 됩니다.)")]
        
        public bool IsEnabled { get; set; } = true;

        [Description("라운드 시작후, 몇초뒤에 게임을 시작할까요?(정수형만 입력해주세요.)")]

        public ushort StartEvnet { get; set; } = 5;

        [Description("핵 시작후 핵를 잠글까요?")]
        
        public bool Warheadlock { get; set; } = true;

        [Description("이벤트 시작시 Broadcast에 뛰우는 메시지를 설정하세요.")]

        public string eventstart { get; set; } = "<size=50>이벤트 시작</colo>";

        [Description("이벤트 종료시 Broadcast에 뜨는 메시지를 설정합니다.")]

        public string eventend { get; set; } = "<size=50>이벤트 끝</color>";
    }
}