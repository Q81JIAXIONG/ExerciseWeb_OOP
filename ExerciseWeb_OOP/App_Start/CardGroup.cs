using System;
using System.Collections.Generic;
using System.Drawing;

namespace ExerciseWeb_OOP.App_Start
{
    /// <summary>
    /// 普克牌組
    /// </summary>
    abstract public class PlayingCardGroup
    {
        /// <summary>
        /// 已翻的牌組
        /// </summary>
        protected List<PlayingCard> FlippedCards = new List<PlayingCard>();
        /// <summary>
        /// 未翻的牌組
        /// </summary>
        protected List<PlayingCard> Unflippeds = new List<PlayingCard>();
        /// <summary>
        /// 未翻紙牌數
        /// </summary>
        public int UnflippedsCount
        {
            get
            {
                return Unflippeds.Count;
            }
        }
        /// <summary>
        /// 已翻紙牌數
        /// </summary>
        public int FlippedCardCount
        {
            get
            {
                return FlippedCards.Count;
            }
        }
        /// <summary>
        /// 抽未翻的牌
        /// </summary>
        /// <param name="Index">抽第幾張</param>
        /// <returns></returns>
        public PlayingCard PumpingUnflop(int Index)
        {
            try
            {
                if (UnflippedsCount < Index || UnflippedsCount == 0)
                    return null;
                else
                {
                    FlippedCards.Add(Unflippeds[Index]);
                    Unflippeds.RemoveAt(Index);
                    return FlippedCards[FlippedCardCount - 1];
                }
            }
            catch 
            {
                throw new Exception(Index.ToString()); ;
            }
            
            
        }
        /// <summary>
        /// 抽已翻的牌插回未翻牌組
        /// </summary>
        /// <param name="Index">抽第幾張</param>
        /// <returns></returns>
        public void UnPumpingUnflop(int Index)
        {
            if (FlippedCardCount < Index || FlippedCardCount == 0)
                return ;
            else
            {
                Unflippeds.Add(FlippedCards[Index]);
                FlippedCards.RemoveAt(Index);
                return ;
            }

        }
    }
    /// <summary>
    /// 沒有鬼牌的簡易牌組(文字)
    /// </summary>
    public class NotGhostCardSimplePlayingCardGroup: PlayingCardGroup
    {
        /// <summary>
        /// 建構子:沒有鬼牌的牌組
        /// </summary>
        public NotGhostCardSimplePlayingCardGroup()
        {
            ProduceCards();
        }
        /// <summary>
        /// 產生卡牌
        /// </summary>
        private void ProduceCards()
        {
            Color FontColor ;
            string Pattern = null;
            string Word = null;
            for (int i = 0; i < 4; i++)
            {
                FontColor = i <= 1 ? Color.Black : Color.Red;
                if (i == 0) 
                    Pattern = "黑桃";
                else if (i == 1)
                    Pattern = "梅花";
                else if (i == 2)
                    Pattern = "方塊";
                else
                    Pattern = "愛心";

                for (int j = 1; j <= 13; j++)
                {
                    if (j == 1)
                        Word = "A";
                    else if (j == 11)
                        Word = "J";
                    else if (j == 12)
                        Word = "Q";
                    else if (j == 13)
                        Word = "K";
                    else
                        Word = j.ToString();

                    Unflippeds.Add(new SimplePlayingCard(FontColor, Pattern, null, Word, Pattern));
                }
            }
        }
    }
    /// <summary>
    /// 有鬼牌的牌組(文字)
    /// </summary>
    public class CardGroupWithGhostSimplePlayingCards : NotGhostCardSimplePlayingCardGroup
    {
        /// <summary>
        /// 建構子:有鬼牌的牌組
        /// </summary>
        public CardGroupWithGhostSimplePlayingCards()
        {
            ProduceCards();
        }
        /// <summary>
        /// 產生卡牌
        /// </summary>
        private void ProduceCards()
        {
            FlippedCards.Add(new SimplePlayingCard(Color.Gray, true,null,"彩鬼"));
            FlippedCards.Add(new SimplePlayingCard(Color.Gray, true, null, "黑白鬼"));
        }
    }

    /// <summary>
    /// 沒有鬼牌的牌組(符號)
    /// </summary>
    public class NotGhostCardPlayingCardGroup : PlayingCardGroup
    {
        /// <summary>
        /// 建構子:沒有鬼牌的牌組
        /// </summary>
        public NotGhostCardPlayingCardGroup()
        {
            ProduceCards();
        }
        /// <summary>
        /// 產生卡牌
        /// </summary>
        private void ProduceCards()
        {
            Color FontColor;
            string Pattern = null;
            string PatternName = null;
            string Word = null;
            for (int i = 0; i < 4; i++)
            {
                FontColor = i <= 1 ? Color.Black : Color.Red;
                if (i == 0)
                {
                    Pattern = "♠";
                    PatternName = "黑桃";
                }
                else if (i == 1)
                {
                    Pattern = "♣";
                    PatternName = "梅花";
                }

                else if (i == 2)
                {
                    Pattern = "♦";
                    PatternName = "方塊";
                }
                else
                {
                    Pattern = "♥";
                    PatternName = "紅心";
                } 

                for (int j = 1; j <= 13; j++)
                {
                    if (j == 1)
                        Word = "A";
                    else if (j == 11)
                        Word = "J";
                    else if (j == 12)
                        Word = "Q";
                    else if (j == 13)
                        Word = "K";
                    else
                        Word = j.ToString();

                    Unflippeds.Add(new SimplePlayingCard(FontColor, Pattern, null, Word, PatternName));
                }
            }
        }
    }
}