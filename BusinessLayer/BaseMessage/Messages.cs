namespace BusinessLayer.BaseMessage
{
    public class Messages
    {
        public static string SUCCESFULLY_ADDED = "Successfully added";
        public static string SUCCESFULLY_DELETED = "Deleted successfull";
        public static string SUCCESFULLY_UPDATE = "Successfully updated";
        public static string PERMANENTLY_SUCCESFULLY_DELETED = "Permanently deleted from database";
        public static string DATA_SUCCESFULLY_RETRIEVED = "Data retrieved successfully";
        public static string NOT_FOUND = "Not Found";
        public static string BLOG_NOT_FOUND = "Blog Not Found";
        public static string EMAIL_NOT_VALID = "A valid email address is required.";
        public static string ID_NOT_VALID = "A valid ID  is required.";
        public static string CAR_ALREADY_RENTED = "Car already rented!";
        public static string DIDNT_HAVE_WAITING_CAR = "You dont have any Waiting car";

        public static string GetRequiredMessage(string propName)
        {
            return $"{propName} is required!";
        }

        public static string GetMinLengthMessage(int length, string propName)
        {
            return $"{propName} must be at leas {length} characters long.";
        }

        public static string GetMaxLengthMessage(int length, string propName)
        {
            return $"{propName} must  be at least {length} characters long!";
        }
        public static string PostivIntegerMessage(string propName)
        {
            return $"{propName} must be a positive integer";
        }
    }
}
