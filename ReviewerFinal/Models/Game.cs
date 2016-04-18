using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewerFinal.Models
{
    public class Game
    {
        #region Fields

        private int _id;
        private string _name;
        private string _publisher;
        private DateTime _releaseData;
        private string _desc;
        private string _reason;

        #endregion

        #region Properties

        [Key]
        public int GameID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Publisher
        {
            get { return _publisher; }
            set { _publisher = value; }
        }

        [Display(Name = "Release Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate
        {
            get { return _releaseData; }
            set { _releaseData = value; }
        }

        [Display(Name = "Game Consoles")]
        public GameSystem GameConsoles { get; set; }

        [Display(Name = "Reason For Greatness")]
        public string ReasonForGreatness
        {
            get { return _reason; }
            set { _reason = value; }
        }

        public string Description
        {
            get { return _desc; }
            set { _desc = value; }
        }

        public string GameImage { get; set; }

        public ICollection<GameReview> Reviews { get; set; }

        #endregion
    }
}
