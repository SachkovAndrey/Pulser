namespace Pulser.Core
{
    public class SiteItem
    {
        #region Constructors

        public SiteItem(int id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
        }

        #endregion

        #region Properties

        public string Address { get; private set; }
        public int Id { get; private set; }
        public string Name { get; private set; }

        #endregion
    }
}
