namespace ExBuddy.OrderBotTags.Objects
{
    using Clio.XmlEngine;
    using Interfaces;

    [XmlElement("SpearFish")]
    public class SpearFish : INamedItem
    {
        public override string ToString() { return this.DynamicToString(); }

        #region INamedItem Members

        [XmlAttribute("Id")]
        public uint Id { get; set; }

        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("LocalName")]
        public string LocalName { get; set; }

        #endregion INamedItem Members
    }
}