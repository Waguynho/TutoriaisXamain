namespace Phoneword.Models
{
    public class BluetoothDeviceBase
    {
        public BluetoothDeviceBase(string address, string name)
        {
            this.Address = address;
            this.Name = name;
        }
        public string Address { get; set; }
        public string Name { get; set; }
    }
}
