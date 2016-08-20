namespace RPG_Go.DungeonMaster
{
    public class Alignment
    {
        private int orderAxis;

        public int OrderAxis // -10 to 10, negative is chaotic, positive is lawful
        {
            get { return orderAxis; }
            set { orderAxis = clipper(value); }
        }

        private int moralAxis;

        public int MoralAxis // -10 to 10, negative is evil, positive is good
        {
            get { return moralAxis; }
            set { moralAxis = clipper(value); }
        }

        public Alignment(int orderAxis, int moralAxis)
        {
            OrderAxis = orderAxis;
            MoralAxis = moralAxis;
        }

        public override string ToString()
        {
            string s = "", t = "";

            if (orderAxis <= -8)
                s = "Extremely Chaotic";
            else if (orderAxis <= -5)
                s = "Very Chaotic";
            else if (orderAxis <= -3)
                s = "Chaotic";
            else if (orderAxis <= -1)
                s = "Kinda Chaotic";
            else if (orderAxis >= -1 && orderAxis <= 1)
                s = "Neutral";
            else if (orderAxis >= 8)
                s = "Extremely Lawful";
            else if (orderAxis >= 5)
                s = "Very Lawful";
            else if (orderAxis >= 3)
                s = "Lawful";
            else if (orderAxis >= 1)
                s = "Kinda Lawful";

            if (moralAxis < -8)
                t = "Extremely Evil";
            else if (moralAxis <= -5)
                t = "Very Evil";
            else if (moralAxis <= -3)
                t = "Evil";
            else if (moralAxis <= -1)
                t = "Kinda Evil";
            else if (moralAxis >= -1 && moralAxis <= 1)
                t = "Neutral";
            else if (moralAxis >= 8)
                t = "Extremely Good";
            else if (moralAxis >= 5)
                t = "Very Good";
            else if (moralAxis >= 3)
                t = "Good";
            else if (moralAxis >= 1)
                t = "Kinda Good";

            return s + "/" + t;
        }

        private int clipper(int i)
        {
            if (i < -10)
                i = -10;
            else if (i > 10)
                i = 10;

            return i;
        }
    }
}