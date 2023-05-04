using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Consimple.Database.Enums
{
    public enum UserType
    {
        [Display(Name = "Admin")]
        Admin = 1,

        [Display(Name = "User")]
        User = 2,
    }

    public static class UserTypeDisplay
    {
        public static string GetDisplayName(UserType userType)
        {
            Type type = userType.GetType();
            FieldInfo fieldInfo = type.GetField(userType.ToString());
            DisplayAttribute displayAttribute = fieldInfo.GetCustomAttribute<DisplayAttribute>();

            if (displayAttribute != null)
            {
                return displayAttribute.Name;
            }
            return userType.ToString();
        }

        public static string[] GetDisplayNames()
        {
            string[] names = Enum.GetNames(typeof(UserType));
            for (int i = 0; i < names.Length; i++)
            {
                UserType userType = (UserType)(i + 1);
                Type type = userType.GetType();
                FieldInfo fieldInfo = type.GetField(userType.ToString());
                DisplayAttribute displayAttribute = fieldInfo.GetCustomAttribute<DisplayAttribute>();

                if (displayAttribute != null)
                {
                    names[i] = displayAttribute.Name;
                }
            }
            return names;
        }
    }
}