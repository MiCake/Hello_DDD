namespace NoInvolution.MassageShop.Infrastructure
{
    /// <summary>
    /// 操作结果类，指示一个操作是成功还是失败，失败则返回错误信息
    /// </summary>
    public class OperationResult
    {
        protected readonly List<OperationError> _errors = new();

        /// <summary>
        /// Flag indicating whether if the operation succeeded or not.
        /// </summary>
        /// <value>True if the operation succeeded, otherwise false.</value>
        public bool Succeeded { get; protected set; }

        /// <summary>
        /// An <see cref="IEnumerable{T}"/> of <see cref="OperationError"/>s containing an errors
        /// that occurred during the identity operation.
        /// </summary>
        /// <value>An <see cref="IEnumerable{T}"/> of <see cref="OperationError"/>s.</value>
        public IEnumerable<OperationError> Errors => _errors;

        /// <summary>
        /// 表示该操作成功
        /// </summary>
        public static OperationResult Success() => new() { Succeeded = true };

        /// <summary>
        /// 表示操作结果失败
        /// </summary>
        /// <param name="errors"></param>
        /// <returns></returns>
        public static OperationResult Failed(params OperationError[] errors)
        {
            var result = new OperationResult { Succeeded = false };
            if (errors != null)
            {
                result._errors.AddRange(errors);
            }
            return result;
        }

        public static OperationResult Failed(Exception ex)
        {
            return Failed(new OperationError
            {
                Exception = ex,
                Description = ex.Message
            });
        }

        public string GetErrorDescription()
        {
            return string.Join("；", _errors.Select(s => s.Description).ToArray());
        }
    }

    /// <summary>
    /// <see cref="OperationResult"/>的泛型版本，包括了成功时需要携带的数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class OperationResult<T> : OperationResult
    {
        public T Data { get; set; }

        public OperationResult()
        {
        }

        public OperationResult(OperationResult original)
        {
            Succeeded = original.Succeeded;
            _errors.AddRange(original.Errors);
        }

        public static OperationResult<T> Success(T data)
            => new() { Succeeded = true, Data = data };

        public new static OperationResult<T> Failed(params OperationError[] errors)
        {
            var original = OperationResult.Failed(errors);
            return new OperationResult<T>(original);
        }

        public static new OperationResult<T> Failed(Exception ex)
        {
            return Failed(new OperationError
            {
                Exception = ex,
                Description = ex.Message
            });
        }

        /// <summary>
        /// 获取结果，如果成功将返回<see cref="Data"/>，否则返回null.
        /// </summary>
        /// <returns></returns>
        public T GetData()
        => Succeeded ? Data : default;
    }

    /// <summary>
    /// 表示操作失败的结果
    /// </summary>
    public class OperationError
    {
        /// <summary>
        /// Gets or sets the code for this error.
        /// </summary>
        /// <value>
        /// The code for this error.
        /// </value>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the description for this error.
        /// </summary>
        /// <value>
        /// The description for this error.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        ///  Gets or sets the exception for this error.
        /// </summary>
        public Exception Exception { get; set; }
    }
}
