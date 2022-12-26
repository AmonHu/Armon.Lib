using System.ComponentModel;

namespace Armon.Lib.Type
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum e)
        {
            var type = e.GetType();

            var members = type.GetMember(e.ToString());
            if (members == null || members.Length <= 0)
            {
                return e.ToString();
            }

            var attributes = members[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes == null || attributes.Length <= 0)
            {
                return e.ToString();
            }

            return ((DescriptionAttribute)attributes[0]).Description;
        }
    }
}
