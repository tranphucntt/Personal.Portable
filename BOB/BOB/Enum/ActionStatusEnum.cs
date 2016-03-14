using System.ComponentModel;

namespace BOB
{
    /// <summary>
    /// Action status enum
    /// </summary>
    public enum ActionStatusEnum
    {
        [Description("Successful")]
        Successed = 0,

        [Description("Failed")]
        Failed = 9999
    }
}