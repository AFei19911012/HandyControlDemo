using HandyControl.Data;

namespace HandyControlDemo.Model
{
    public struct ChatInfoModel
    {
        public object Message { get; set; }

        public string SenderId { get; set; }

        public ChatRoleType Role { get; set; }

        public ChatMessageType Type { get; set; }

        public object Enclosure { get; set; }
    }
}
