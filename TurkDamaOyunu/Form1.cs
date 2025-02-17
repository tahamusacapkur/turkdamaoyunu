namespace TurkDamaOyunu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        PictureBox[,] P;
        String color = "r", k = "", B1 = "", B2 = "",B3="",k2= "";
        int yesil = 0, kýrmýzý = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            P = new PictureBox[8, 9];
            int sol = 2, top = 2;
            Color[] colors = new Color[] { Color.White, Color.Black };
            for (int i=0; i < 8; i++){
                sol=2;
              
                if (i % 2 == 0) { colors[0] = Color.White; colors[1] = Color.Black; }
                else { colors[1] = Color.White; colors[0] = Color.Black; }
                for (int j=0; j<9; j++)
                {
                    P[i, j] = new PictureBox();
                    P[i, j].BackColor = colors[(j % 2 == 0) ? 1 : 0];
                    P[i, j].Location = new Point(sol, top);
                    P[i, j].Size = new Size(60, 60);
                    sol += 60;
                    P[i, j].Name = i + " " + j;
                    if (i == 1 || i == 2) { P[i, j].Image = Properties.Resources.r; P[i, j].Name += " r"; }
                    else if (i == 5 || i == 6) { P[i, j].Image = Properties.Resources.g; P[i, j].Name += " g"; }
                    P[i, j].SizeMode = PictureBoxSizeMode.CenterImage;
                   

                    
                    P[i, j].Click += (sender3, e3) =>

                    {
                        PictureBox p = sender3 as PictureBox;
                        if (p.Image != null)
                        {
                            int c = -1, x, y;
                            F();
                            if (p.Name.Split(' ')[2] == "b")
                            {
                                if (color == "r") color = "g";
                                else color = "r";
                                x = Convert.ToInt32(k.Split(' ')[0]);
                                y = Convert.ToInt32(k.Split(' ')[1]);
                                B1 = "";
                                B2 = "";
                                B3 = "";
                                if (k.Split(' ')[2] == "r")
                                {
                                    p.Image = Properties.Resources.r;
                                    p.Name = p.Name.Replace("b", "r");
                                }
                                else
                                if (k.Split(' ')[2] == "g")
                                {
                                    p.Image = Properties.Resources.g;
                                    p.Name = p.Name.Replace("b", "g");
                                }
                                P[x, y].Image = null;
                                if (k2 != "")
                                {
                                    x = Convert.ToInt32(k2.Split(' ')[0]);
                                    y = Convert.ToInt32(k2.Split(' ')[1]);
                                    P[x, y].Image = null;
                                    if (k2.Split(' ')[2] == "r") yesil++;
                                    else kýrmýzý++;
                                    label1.Text = yesil + "";
                                    label2.Text = kýrmýzý + "";
                                    k2 = "";

                                }
                            }
                            else
                            if (p.Name.Split(' ')[2] == color)
                            {
                                x = Convert.ToInt32(p.Name.Split(' ')[0]);
                                y = Convert.ToInt32(p.Name.Split(' ')[1]);
                                k = p.Name;
                                if (p.Name.Split(' ')[2] == "r") c = 1;
                                try
                                {
                                if (P[x + c, y].Image == null)
                                {
                                    P[x + c, y].Image = Properties.Resources.b;
                                    P[x + c, y].Name = (x + c) + " " + (y) + " b";
                                    B1 = (x + c) + " " + (y);

                                }
                                else
                                    if (P[x + c, y].Name.Split(' ')[2] != p.Name.Split(' ')[2] && P[x + (c * 2), y].Image == null)
                                    {
                                        P[x + (c * 2), y].Image = Properties.Resources.b;
                                        P[x + (c * 2), y].Name = (x+(c+2)+" "+(y)+" b");
                                        B1 = (x + (c * 2)) + " " + (y);
                                        k2 = (x + c) + " " + (y) + " " + P[x + c, y].Name.Split(' ')[2];
                                    }
                                }
                                catch { }
                                try
                                {
                                    if (P[x, y - 1].Image == null)
                                    {
                                        P[x, y - 1].Image = Properties.Resources.b;
                                        P[x, y - 1].Name = (x) + " " + (y - 1) + " b";
                                        B2 = (x) + " " + (y - 1);
                                    }
                                    else
                                        if (P[x , y-1].Name.Split(' ')[2] != p.Name.Split(' ')[2] && P[x , y-2 ].Image == null)
                                        {
                                            P[x, y-2].Image = Properties.Resources.b;
                                            P[x , y-2].Name = (x+ " " + (y-2) + " b");
                                            B2 = (x) + " " + (y-2);
                                            k2 = x  + " " + (y-1) + " " + P[x , y-1].Name.Split(' ')[2];
                                        }
                                }
                                catch { }
                                try
                                {
                                    if (P[x, y + 1].Image == null)
                                    {
                                        P[x, y + 1].Image = Properties.Resources.b;
                                        P[x, y + 1].Name = (x) + " " + (y + 1) + " b";
                                        B3 = (x) + " " + (y + 1);
                                    }
                                    else
                                        if (P[x , y+1].Name.Split(' ')[2] != p.Name.Split(' ')[2] && P[x , y+2].Image == null)
                                        {
                                            P[x, y+2].Image = Properties.Resources.b;
                                            P[x , y+2].Name = (x  + " " + (y+2) + " b");
                                            B2 = (x) + " " + (y+2);
                                            k2 = x  + " " + (y+1) + " " + P[x, y+1].Name.Split(' ')[2];
                                        }
                                }
                                catch { }

                            }

                        }
                    };
                    G.Controls.Add(P[i, j]);
                }
                top += 60;

            }
        }
        public void F()
        {
            if(B1 != "")
            {
                int x, y;
                x = Convert.ToInt32(B1.Split(' ')[0]);
                y = Convert.ToInt32(B1.Split(' ')[1]);
                P[x, y].Image = null;

            }
            if(B2 != "")
            {
                int x, y;
                x = Convert.ToInt32(B2.Split(' ')[0]);
                y = Convert.ToInt32(B2.Split(' ')[1]);
                P[x, y].Image = null;
            }
            if (B3 != "")
            {
                int x, y;
                x = Convert.ToInt32(B3.Split(' ')[0]);
                y = Convert.ToInt32(B3.Split(' ')[1]);
                P[x, y].Image = null;
            }

        }

    }

}