using Sainkadelux.data.Services;
using Sainkadelux.Niveles.Letra_a;
using Sainkadelux.ui.Niveles.Abecedario.Letra_a;
using Sainkadelux.ui.Niveles.Abecedario.Letra_b;
using Sainkadelux.ui.Niveles.Letra_e;
using Sainkadelux.ui.Niveles.Letra_i;
using Sainkadelux.ui.Niveles.Letra_o;
using Sainkadelux.ui.Niveles.Letra_u;

namespace Sainkadelux.ui.Niveles.Abecedario;

public partial class FirtsAbecedarioPage : ContentPage
{

    private int currentImageIndex = 0;
    public FirtsAbecedarioPage()
    {
        InitializeComponent();

        ChangeImageWithAnimationA();
        ChangeImageWithAnimationB();
        ChangeImageWithAnimationC();
        ChangeImageWithAnimationD();
        ChangeImageWithAnimationE();
        ChangeImageWithAnimationF();
        ChangeImageWithAnimationG();
        ChangeImageWithAnimationH();
        ChangeImageWithAnimationI();
        ChangeImageWithAnimationJ();
        ChangeImageWithAnimationK();
        ChangeImageWithAnimationL();
        ChangeImageWithAnimationM();
        ChangeImageWithAnimationN();
        ChangeImageWithAnimation—();
        ChangeImageWithAnimationO();
        ChangeImageWithAnimationP();
        ChangeImageWithAnimationQ();
        ChangeImageWithAnimationR();
        ChangeImageWithAnimationS();
        ChangeImageWithAnimationT();
        ChangeImageWithAnimationU();
        ChangeImageWithAnimationV();
        ChangeImageWithAnimationW();
        ChangeImageWithAnimationX();
        ChangeImageWithAnimationY();
        ChangeImageWithAnimationZ();
    }

    private async void OnImageTappedA(object sender, EventArgs e)
    {
        Navigation.InsertPageBefore(new LevelPageAA(), this);
        await Navigation.PopAsync();
    }
    private async void OnImageTappedB(object sender, EventArgs e)
    {
        Navigation.InsertPageBefore(new LetraB(), this);
        await Navigation.PopAsync();
    }
    private async void BackButton(object sender, EventArgs e)
    {
        Navigation.InsertPageBefore(new WorldPage(), this);
        await Navigation.PopAsync();
    }
    private async void ChangeImageWithAnimationA()
    {
        string[] images = { "ab.png", "al.png" };
        while (true)
        {
            await animatedImageA.FadeTo(0, 500);
            currentImageIndex = (currentImageIndex + 1) % images.Length;
            animatedImageA.Source = images[currentImageIndex];
            await animatedImageA.FadeTo(1, 500);
            await Task.Delay(2000);
        }
    }

    private async void ChangeImageWithAnimationB()
    {
        string[] images = { "bb.png", "bl.png" };
        while (true)
        {
            await animatedImageB.FadeTo(0, 500);
            currentImageIndex = (currentImageIndex + 1) % images.Length;
            animatedImageB.Source = images[currentImageIndex];
            await animatedImageB.FadeTo(1, 500);
            await Task.Delay(2000);
        }
    }

    private async void ChangeImageWithAnimationC()
    {
        string[] images = { "cb.png", "cl.png" };
        while (true)
        {
            await animatedImageC.FadeTo(0, 500);
            currentImageIndex = (currentImageIndex + 1) % images.Length;
            animatedImageC.Source = images[currentImageIndex];
            await animatedImageC.FadeTo(1, 500);
            await Task.Delay(2000);
        }
    }

    private async void ChangeImageWithAnimationD()
    {
        string[] images = { "db.png", "dl.png" };
        while (true)
        {
            await animatedImageD.FadeTo(0, 500);
            currentImageIndex = (currentImageIndex + 1) % images.Length;
            animatedImageD.Source = images[currentImageIndex];
            await animatedImageD.FadeTo(1, 500);
            await Task.Delay(2000);
        }
    }

    private async void ChangeImageWithAnimationE()
    {
        string[] images = { "eb.png", "el.png" };
        while (true)
        {
            await animatedImageE.FadeTo(0, 500);
            currentImageIndex = (currentImageIndex + 1) % images.Length;
            animatedImageE.Source = images[currentImageIndex];
            await animatedImageE.FadeTo(1, 500);
            await Task.Delay(2000);
        }
    }

    private async void ChangeImageWithAnimationF()
    {
        string[] images = { "fb.png", "fl.png" };
        while (true)
        {
            await animatedImageF.FadeTo(0, 500);
            currentImageIndex = (currentImageIndex + 1) % images.Length;
            animatedImageF.Source = images[currentImageIndex];
            await animatedImageF.FadeTo(1, 500);
            await Task.Delay(2000);
        }
    }

    private async void ChangeImageWithAnimationG()
    {
        string[] images = { "gb.png", "gl.png" };
        while (true)
        {
            await animatedImageG.FadeTo(0, 500);
            currentImageIndex = (currentImageIndex + 1) % images.Length;
            animatedImageG.Source = images[currentImageIndex];
            await animatedImageG.FadeTo(1, 500);
            await Task.Delay(2000);
        }
    }

    private async void ChangeImageWithAnimationH()
    {
        string[] images = { "hb.png", "hl.png" };
        while (true)
        {
            await animatedImageH.FadeTo(0, 500);
            currentImageIndex = (currentImageIndex + 1) % images.Length;
            animatedImageH.Source = images[currentImageIndex];
            await animatedImageH.FadeTo(1, 500);
            await Task.Delay(2000);
        }
    }

    private async void ChangeImageWithAnimationI()
    {
        string[] images = { "ib.png", "il.png" };
        while (true)
        {
            await animatedImageI.FadeTo(0, 500);
            currentImageIndex = (currentImageIndex + 1) % images.Length;
            animatedImageI.Source = images[currentImageIndex];
            await animatedImageI.FadeTo(1, 500);
            await Task.Delay(2000);
        }
    }

    private async void ChangeImageWithAnimationJ()
    {
        string[] images = { "jb.png", "jl.png" };
        while (true)
        {
            await animatedImageJ.FadeTo(0, 500);
            currentImageIndex = (currentImageIndex + 1) % images.Length;
            animatedImageJ.Source = images[currentImageIndex];
            await animatedImageJ.FadeTo(1, 500);
            await Task.Delay(2000);
        }
    }

    private async void ChangeImageWithAnimationK()
    {
        string[] images = { "kb.png", "kl.png" };
        while (true)
        {
            await animatedImageK.FadeTo(0, 500);
            currentImageIndex = (currentImageIndex + 1) % images.Length;
            animatedImageK.Source = images[currentImageIndex];
            await animatedImageK.FadeTo(1, 500);
            await Task.Delay(2000);
        }
    }

    private async void ChangeImageWithAnimationL()
    {
        string[] images = { "lb.png", "ll.png" };
        while (true)
        {
            await animatedImageL.FadeTo(0, 500);
            currentImageIndex = (currentImageIndex + 1) % images.Length;
            animatedImageL.Source = images[currentImageIndex];
            await animatedImageL.FadeTo(1, 500);
            await Task.Delay(2000);
        }
    }

    private async void ChangeImageWithAnimationM()
    {
        string[] images = { "mb.png", "ml.png" };
        while (true)
        {
            await animatedImageM.FadeTo(0, 500);
            currentImageIndex = (currentImageIndex + 1) % images.Length;
            animatedImageM.Source = images[currentImageIndex];
            await animatedImageM.FadeTo(1, 500);
            await Task.Delay(2000);
        }
    }

    private async void ChangeImageWithAnimationN()
    {
        string[] images = { "nb.png", "nl.png" };
        while (true)
        {
            await animatedImageN.FadeTo(0, 500);
            currentImageIndex = (currentImageIndex + 1) % images.Length;
            animatedImageN.Source = images[currentImageIndex];
            await animatedImageN.FadeTo(1, 500);
            await Task.Delay(2000);
        }
    }

    private async void ChangeImageWithAnimation—()
    {
        string[] images = { "nnb.png", "nnl.png" }; 
        while (true)
        {
            await animatedImageNtilde.FadeTo(0, 500);
            currentImageIndex = (currentImageIndex + 1) % images.Length;
            animatedImageNtilde.Source = images[currentImageIndex];
            await animatedImageNtilde.FadeTo(1, 500);
            await Task.Delay(2000);
        }
    }

    private async void ChangeImageWithAnimationO()
    {
        string[] images = { "ob.png", "ol.png" };
        while (true)
        {
            await animatedImageO.FadeTo(0, 500);
            currentImageIndex = (currentImageIndex + 1) % images.Length;
            animatedImageO.Source = images[currentImageIndex];
            await animatedImageO.FadeTo(1, 500);
            await Task.Delay(2000);
        }
    }

    private async void ChangeImageWithAnimationP()
    {
        string[] images = { "pb.png", "pl.png" };
        while (true)
        {
            await animatedImageP.FadeTo(0, 500);
            currentImageIndex = (currentImageIndex + 1) % images.Length;
            animatedImageP.Source = images[currentImageIndex];
            await animatedImageP.FadeTo(1, 500);
            await Task.Delay(2000);
        }
    }

    private async void ChangeImageWithAnimationQ()
    {
        string[] images = { "qb.png", "ql.png" };
        while (true)
        {
            await animatedImageQ.FadeTo(0, 500);
            currentImageIndex = (currentImageIndex + 1) % images.Length;
            animatedImageQ.Source = images[currentImageIndex];
            await animatedImageQ.FadeTo(1, 500);
            await Task.Delay(2000);
        }
    }

    private async void ChangeImageWithAnimationR()
    {
        string[] images = { "rb.png", "rl.png" };
        while (true)
        {
            await animatedImageR.FadeTo(0, 500);
            currentImageIndex = (currentImageIndex + 1) % images.Length;
            animatedImageR.Source = images[currentImageIndex];
            await animatedImageR.FadeTo(1, 500);
            await Task.Delay(2000);
        }
    }

    private async void ChangeImageWithAnimationS()
    {
        string[] images = { "sb.png", "sl.png" };
        while (true)
        {
            await animatedImageS.FadeTo(0, 500);
            currentImageIndex = (currentImageIndex + 1) % images.Length;
            animatedImageS.Source = images[currentImageIndex];
            await animatedImageS.FadeTo(1, 500);
            await Task.Delay(2000);
        }
    }

    private async void ChangeImageWithAnimationT()
    {
        string[] images = { "tb.png", "tl.png" };
        while (true)
        {
            await animatedImageT.FadeTo(0, 500);
            currentImageIndex = (currentImageIndex + 1) % images.Length;
            animatedImageT.Source = images[currentImageIndex];
            await animatedImageT.FadeTo(1, 500);
            await Task.Delay(2000);
        }
    }

    private async void ChangeImageWithAnimationU()
    {
        string[] images = { "ub.png", "ul.png" };
        while (true)
        {
            await animatedImageU.FadeTo(0, 500);
            currentImageIndex = (currentImageIndex + 1) % images.Length;
            animatedImageU.Source = images[currentImageIndex];
            await animatedImageU.FadeTo(1, 500);
            await Task.Delay(2000);
        }
    }

    private async void ChangeImageWithAnimationV()
    {
        string[] images = { "vb.png", "vl.png" };
        while (true)
        {
            await animatedImageV.FadeTo(0, 500);
            currentImageIndex = (currentImageIndex + 1) % images.Length;
            animatedImageV.Source = images[currentImageIndex];
            await animatedImageV.FadeTo(1, 500);
            await Task.Delay(2000);
        }
    }

    private async void ChangeImageWithAnimationW()
    {
        string[] images = { "wb.png", "wl.png" };
        while (true)
        {
            await animatedImageW.FadeTo(0, 500);
            currentImageIndex = (currentImageIndex + 1) % images.Length;
            animatedImageW.Source = images[currentImageIndex];
            await animatedImageW.FadeTo(1, 500);
            await Task.Delay(2000);
        }
    }

    private async void ChangeImageWithAnimationX()
    {
        string[] images = { "xb.png", "xl.png" };
        while (true)
        {
            await animatedImageX.FadeTo(0, 500);
            currentImageIndex = (currentImageIndex + 1) % images.Length;
            animatedImageX.Source = images[currentImageIndex];
            await animatedImageX.FadeTo(1, 500);
            await Task.Delay(2000);
        }
    }

    private async void ChangeImageWithAnimationY()
    {
        string[] images = { "yb.png", "yl.png" };
        while (true)
        {
            await animatedImageY.FadeTo(0, 500);
            currentImageIndex = (currentImageIndex + 1) % images.Length;
            animatedImageY.Source = images[currentImageIndex];
            await animatedImageY.FadeTo(1, 500);
            await Task.Delay(2000);
        }
    }

    private async void ChangeImageWithAnimationZ()
    {
        string[] images = { "zb.png", "zl.png" };
        while (true)
        {
            await animatedImageZ.FadeTo(0, 500);
            currentImageIndex = (currentImageIndex + 1) % images.Length;
            animatedImageZ.Source = images[currentImageIndex];
            await animatedImageZ.FadeTo(1, 500);
            await Task.Delay(2000);
        }
    }

}