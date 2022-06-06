namespace Leopard.Api {
	public class OperationResult<T> {
		public bool Success { get; set; }

		public string? FailureMessage { get; set; }

		private Exception? Exception { get; set; }

		public T? Data { get; set; }

		public int? TotalCount { get; set; }

		public OperationResult() => this.Success = true;

		protected OperationResult(T result) {
			this.Success = true;
			this.Data = result;
		}

		protected OperationResult(T result, int count) {
			this.Success = true;
			this.Data = result;
			this.TotalCount = count;
		}

		protected OperationResult(string message) {
			this.Success = false;
			this.FailureMessage = message;
		}

		protected OperationResult(Exception ex) {
			this.Success = false;
			this.Exception = ex;
			this.FailureMessage = ex.Message;
			if (ex.InnerException == null)
				return;
			this.FailureMessage = this.FailureMessage + "- IExp: " + ex.InnerException.Message;
		}

		public static OperationResult<T> SuccessResult(T result) => new OperationResult<T>(result);

		public static OperationResult<T> SuccessResult(T result, int count) => new OperationResult<T>(result, count);

		public static OperationResult<T> FailureResult(string message) => new OperationResult<T>(message);

		public static OperationResult<T> ExceptionResult(Exception ex) => new OperationResult<T>(ex);

		public bool IsException() => this.Exception != null;
	}
}
