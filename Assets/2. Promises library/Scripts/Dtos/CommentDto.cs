using System;

namespace PromisesLibrary
{
    [Serializable]
    public class CommentDto
    {
        public int postId;
        public int id;
        public string name;
        public string email;
        public string body;
    }
}