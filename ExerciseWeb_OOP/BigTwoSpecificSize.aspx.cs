using System;
using ExerciseWeb_OOP.App_Start;
using System.Drawing;

namespace ExerciseWeb_OOP
{
    public partial class BigTwoSpecificSize : System.Web.UI.Page
    {
        /// <summary>
        /// 普克牌組
        /// </summary>
        PlayingCardGroup NotGhostCards;
        /// <summary>
        /// 比大小物件
        /// </summary>
        SpecificSize SS ;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NotGhostCards = new NotGhostCardPlayingCardGroup();
                SS = new App_Start.BigTwoSpecificSize(NotGhostCards);
                Shuffle();
                Session["PlayingCardGroup"] = NotGhostCards;
                Session["SpecificSize"] = SS;
                //Watch();
                PresentCards(null, null);
                PresentingCardsCount();
            }
            else
            {
                NotGhostCards = (PlayingCardGroup)(Session["PlayingCardGroup"]);
                SS = (SpecificSize)(Session["SpecificSize"]);
            }
        }
        /// <summary>
        /// 重新洗牌按鈕Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Shuffle_Button_Click(object sender, EventArgs e)
        {
            Shuffle();
            PresentingCardsCount();
            PresentCards(null, null);
        }
        /// <summary>
        /// 抽牌比大小按鈕Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DrawAndSpecificSize_Button_Click(object sender, EventArgs e)
        {
            //抽牌
            PlayingCard Card1 = NotGhostCards.PumpingUnflop(0);
            PlayingCard Card2 = NotGhostCards.PumpingUnflop(0);

            PresentCards(Card1, Card2);
            Comparison(Card1, Card2);
            PresentingCardsCount();
            Session["PlayingCardGroup"] = NotGhostCards;
        }

        /// <summary>
        /// 洗牌
        /// </summary>
        private void Shuffle()
        {
            for (int i = 0; i < NotGhostCards.FlippedCardCount; )
            {
                NotGhostCards.UnPumpingUnflop(0);
            }
            Random ra = new Random();
            for (int i = 0; i < 208; i++)
            {
                NotGhostCards.PumpingUnflop(ra.Next(52));
                NotGhostCards.UnPumpingUnflop(0);
            }
        } 
        /// <summary>
        /// 顯示牌
        /// </summary>
        /// <param name="_Card1"></param>
        /// <param name="_Card2"></param>
        private void PresentCards(PlayingCard _Card1, PlayingCard _Card2)
        {
            if (_Card1 != null)
            {
                FirstcardWordUp.Text = _Card1.Word;
                FirstcardWordDown.Text = _Card1.Word;
                FirstcardPattern_Label.Text = _Card1.Pattern;
                FirstcardWordUp.ForeColor = _Card1.Color;
                FirstcardWordDown.ForeColor = _Card1.Color;
                FirstcardPattern_Label.ForeColor = _Card1.Color;

                SecondcardWordUp.Text = _Card2.Word;
                SecondcardWordDown.Text = _Card2.Word;
                SecondCardPattern_Label.Text = _Card2.Pattern;
                SecondcardWordUp.ForeColor = _Card2.Color;
                SecondcardWordDown.ForeColor = _Card2.Color;
                SecondCardPattern_Label.ForeColor = _Card2.Color;
            }
            else
            {
                FirstcardWordUp.Text = "";
                FirstcardWordDown.Text = "";
                FirstcardPattern_Label.Text = "完";
                FirstcardWordUp.ForeColor = Color.Black;
                FirstcardWordDown.ForeColor = Color.Black;
                FirstcardPattern_Label.ForeColor = Color.Black;

                SecondcardWordUp.Text = "";
                SecondcardWordDown.Text = "";
                SecondCardPattern_Label.Text = "完";
                SecondcardWordUp.ForeColor = Color.Black;
                SecondcardWordDown.ForeColor = Color.Black;
                SecondCardPattern_Label.ForeColor = Color.Black;
            }
        }
        /// <summary>
        /// 比大小/顯示結果
        /// </summary>
        /// <param name="_Card1"></param>
        /// <param name="_Card2"></param>
        private void Comparison(PlayingCard _Card1, PlayingCard _Card2)
        {
            Result.Text = SS.ComparisonTwoCards(_Card1, _Card2);
        }
        /// <summary>
        /// 呈現翻牌數
        /// </summary>
        private void PresentingCardsCount()
        {
            UnflippedsCount_Label.Text = NotGhostCards.UnflippedsCount.ToString();
            flippedsCount_Label.Text = NotGhostCards.FlippedCardCount.ToString();
        }
        /// <summary>
        /// 看未翻的所有牌
        /// </summary>
        private void Watch()
        {
            for (int i = 0; i < NotGhostCards.UnflippedsCount;)
            {
                PlayingCard p = NotGhostCards.PumpingUnflop(0);
                Label1.Text = Label1.Text + p.Pattern +":" + p.Word +":"+ p.PatternRank + ":" + p.WordRank+ "<br />";
            }
            PresentingCardsCount();
        }
    }
}