namespace Mollie.Models.Permission {
    public class PermissionResponse {
        public string Resource { get; set; }
        public string Id { get; set; }
        public string Description { get; set; }
        public string Warning { get; set; }
        public bool Granted { get; set; }
    }
}