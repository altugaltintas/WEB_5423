namespace CoreCrud_5423.Models.Concrete
{
    public class MovieActor
    {
        // ara tablo olduğu için zten iki id beraber primary key olacak , bu yüzden bir kez daha primary key verilmez.
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }

        public int ActorId { get; set; }
        public virtual Actor  Actor { get; set; }

    }
}