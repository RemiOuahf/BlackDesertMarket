using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DiscordTokenGrabber
{
    public class ImageObject
    {
        public string url;
        public int height;
        public int width;
    }

    public class EmbedFooterObject
    {
        public string text;
        public string icon_url;
    }

    public class EmbedObject
    {
        public string title;
        public string type;
        public string description;
        public string url;
        public int color;
        public EmbedFooterObject footer = new EmbedFooterObject();
        public ImageObject image = new ImageObject();
    }

    public class DiscordMessageStructure
    {
        public string content;
        public string username;
        public string avatar_url;
        public List<EmbedObject> embeds = new List<EmbedObject>();
    }

    internal class DiscordMessageAPI
    {
        public static DiscordMessageStructure CreateMessage(string _message, string _username = "Asuna", string _avatar_url = "https://www.kindpng.com/picc/b/88-883023_sword-art-online-asuna-yuuki-hyper-accion-hd.png")
        {
            DiscordMessageStructure _discordMessageStruct = new DiscordMessageStructure();

            _discordMessageStruct.content = _message;
            _discordMessageStruct.username = _username;
            _discordMessageStruct.avatar_url = _avatar_url;

            return _discordMessageStruct;
        }
        public static DiscordMessageStructure CreateEmbedMessage(string _message, List<EmbedObject> _embeds, string _username = "ta maman", string _avatar_url = "https://intelligence-artificielle.com/wp-content/uploads/2022/03/robocop-758x426.jpg")
        {
            DiscordMessageStructure _discordMessageStruct = new DiscordMessageStructure();

            _discordMessageStruct.content = _message;
            _discordMessageStruct.embeds = _embeds;

            return _discordMessageStruct;
        }
        public static EmbedObject CreateEmbed(string _title, string _type = "", string _description = "", string _url = "", int color = 0, EmbedFooterObject _footer = null, ImageObject _image = null)
        {
            EmbedObject _embed = new EmbedObject();

            _embed.title = _title;
            _embed.type = _type;
            _embed.description = _description;
            _embed.url = _url;
            _embed.color = color;
            _embed.footer = _footer;
            _embed.image = _image;

            return _embed;
        }
        public static EmbedFooterObject CreateFooter(string _text, string _icon_url = "")
        {
            EmbedFooterObject _footer = new EmbedFooterObject();

            _footer.text = _text;
            _footer.icon_url = _icon_url;

            return _footer;
        }
    }
}
