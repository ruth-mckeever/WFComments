namespace WFComments
{
    public class UserComment : IComparable<UserComment>
    {
        private string rawComment;
        private string sanitizedComment;
        private string rawTitle;
        private string sanitizedTitle;
        private DateTime createdTimestamp;

        public string RawComment
        {
            get { return rawComment; }
            set { rawComment = value; }
        }

        public string SanitizedComment
        {
            get { return sanitizedComment; }
            set { sanitizedComment = value; }
        }

        public string RawTitle
        {
            get { return rawTitle; }
            set { rawTitle = value; }
        }

        public string SanitizedTitle
        {
            get { return sanitizedTitle; }
            set { sanitizedTitle = value; }
        }

        public DateTime CreatedTimestamp
        {
            get { return createdTimestamp; }
        }

        public UserComment(string rawTitle, string rawComment)
        {
            this.rawComment = rawComment;
            sanitizedComment = SanitizeService.SanitizeTextJSON(rawComment);
            this.rawTitle = rawTitle;
            sanitizedTitle = SanitizeService.SanitizeTextJSON(rawTitle);
            createdTimestamp = DateTime.Now;
        }

        public override bool Equals(object? obj)
        {
            //We will update this whenever we change user comment
            if (!(obj is UserComment))
            {
                return false;
            }
            var userComment = (UserComment)obj;
            if (userComment.sanitizedComment.Equals(sanitizedComment) && userComment.sanitizedTitle.Equals(sanitizedTitle))
            {
                return true;
            }
            return false;
        }
        public static bool operator ==(UserComment left, UserComment right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(UserComment left, UserComment right)
        {
            return !left.Equals(right);
        }
        public override int GetHashCode()
        {
            //We will update this whenever we change user comment
            return (sanitizedTitle, sanitizedComment).GetHashCode();
        }
        public int CompareTo(UserComment? other)
        {
            int result = string.Compare(sanitizedTitle, other.SanitizedTitle, ignoreCase: true);
            if (result == 0)
            {
                result = string.Compare(sanitizedComment, other.SanitizedComment, ignoreCase: true);
            }
            return result;
        }
    }



}
