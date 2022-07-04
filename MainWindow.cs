using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace fishe
{
    class MainWindow : Window
    {
    	[UI] private Image imagebox = null;
        [UI] private Button _button1 = null;

        public MainWindow() : this(new Builder("MainWindow.glade")) { }

        private MainWindow(Builder builder) : base(builder.GetRawOwnedObject("MainWindow"))
        {
            builder.Autoconnect(this);
            
            using (var stream = new System.IO.MemoryStream(ExtractResource("icon.png")))
            {
                Icon = new Gdk.Pixbuf(stream);
            }
            
            using (var stream = new System.IO.MemoryStream(ExtractResource("fishe.png")))
            {
                imagebox.Pixbuf = new Gdk.Pixbuf(stream);
            }

            DeleteEvent += Window_DeleteEvent;
            _button1.Clicked += Button1_Clicked;
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }

        private void Button1_Clicked(object sender, EventArgs a)
        {
            Application.Quit();
        }
        private static byte[] ExtractResource(string filename)
        {
            System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
            using System.IO.Stream resFilestream = a.GetManifestResourceStream(filename);
            if (resFilestream == null) return null;
            byte[] ba = new byte[resFilestream.Length];
            resFilestream.Read(ba, 0, ba.Length);
            return ba;
        }
    }
}
