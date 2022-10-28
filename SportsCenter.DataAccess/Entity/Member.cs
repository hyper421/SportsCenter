namespace SportsCenter.DataAccess.Entity
{
    public class Member
    {
        public int Id { get; set; }
        public int IsActive { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime CreateTime { get; set; }
        public string ImagePath { get; set; }
        public int Role { get; set; }

        public virtual ICollection<LocationOrder> LocationOrder { get; set; }
        public virtual ICollection<ProductsCart> ProductsCart { get; set; }
        public virtual ICollection<ProductsOrder> ProductsOrder { get; set; }
        public virtual ICollection<Post> Post { get; set; }
        public virtual ICollection<Message> Messages { get; set; }

    }
}