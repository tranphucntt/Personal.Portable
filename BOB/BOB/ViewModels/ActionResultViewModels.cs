
namespace BOB
{
    /// <summary>
    /// Action result view models
    /// </summary>
    public class ActionResultViewModels
    {
        EnumChangeService enumChangeService;

        public ActionResultViewModels()
        {
            enumChangeService = new EnumChangeService();
        }

        /// <summary>
        ///  Action status code result
        /// </summary>
        public ActionStatusEnum Code { get; set; }

        /// <summary>
        ///  Action result message
        /// </summary>
        public string Message
        {
            get
            {                
                return
                    enumChangeService
                        .GetEnumDescription(
                            (ActionStatusEnum)Code
                        );
            }
        }

        /// <summary>
        ///  Action expression
        /// </summary>
        public string Expression { get; set; }

        /// <summary>
        /// Action result
        /// </summary>
        public object Result { get; set; }
    }
}