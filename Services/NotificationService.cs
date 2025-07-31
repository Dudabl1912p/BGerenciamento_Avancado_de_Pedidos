namespace GerenciarProdutos.Services
{
    public class NotificationService
    {
        public event Action<string, string> OnShowMessage;

        public void ShowSuccess(string message) => OnShowMessage?.Invoke(message, "success");

        public void ShowError(string message) => OnShowMessage?.Invoke(message, "danger");

        public void ShowInfo(string message) => OnShowMessage?.Invoke(message, "info");
    }

}
