namespace pnut
{
	public class Entity
	{
		public string Name { get; private set; }
		public string[] Tags { get; private set; }

		public Entity(string name, string[] tags = null)
		{
			Name = name;
			if (tags == null)
				Tags = new string[0];
			else
				Tags = tags;
		}
	}
}
