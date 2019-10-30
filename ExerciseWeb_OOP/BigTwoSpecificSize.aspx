<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BigTwoSpecificSize.aspx.cs" Inherits="ExerciseWeb_OOP.BigTwoSpecificSize" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>大老二比大小</title>
    <style>
        .banner {
            width:550px;
            height:250px;
            position:absolute;
        }
        .banner-show {
            height:198px;
            width:548px;
            border:1px solid black;
            display:flex;
            position:absolute;
            background-color:bisque;
        }
        .banner-operate {
            display:flex;
            width:548px;
            height:45px;
            border:1px solid black;
            position:absolute;
            bottom:0;
        }
        .banner-botton {
            margin :10px 5px;
            width:300px;
        }
        .banner-count {
            width:250px;
            margin:5px;
        }
        .fircard {
            position:absolute;
            left:10px;
            top:10px;
        }
        .Seccard {
            position:absolute;
            right:10px;
            top:10px;
        }
        .Result {
            width: 98px;
            height:98px;
            display:inline-block;
            position:absolute;
            top:50px;
            left:226px;
            border:1px solid black;
            background-color:burlywood;
        }
        .card {
            width: 128px;
            height:178px;
            background-color :white;
            border:1px solid black;
        }
        .cardWor {
            height:25px;
            width:30px;
        }
        .cardWordUp {
            display:inline-block;
            position:absolute;
            left:0;
            top:0;
        }
        .cardWordDown {
            display:inline-block;
            position:absolute;
            right:0;
            bottom:0;
        }
        .cardPattern {
            height:60px;
            width:60px;
            display:inline-block;
            position:absolute;
            top:59px;
            left:34px;
            text-align: center;
        }
        .Pattern {
            font-size:50px;
        }
        .Word {
            display:block;
            text-align: center;
        }
        #Shuffle_Button {
            width:140px;
        }
        #DrawAndSpecificSize_Button {
            width:140px;
        }
        .Resultword {
            position:absolute;
            top:20px;
            left:24px;
            text-align: center;
            font-size:50px;
        }
        .UnflippedsCount {
            display :inline-block;
        }
        .flippedsCount {
            display :inline-block;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" onsubmit="return CheckCardCount()">
        <div class ="banner">   
            <div class="banner-show">
                <div id="card1" class="card fircard">   
                    <div id="card1WordUp" class="cardWordUp cardWor">
                        <asp:Label ID="FirstcardWordUp" runat="server" Text="上" CssClass="Word"></asp:Label>
                    </div>
                    <div id ="card1Pattern" class="cardPattern">   
                        <asp:Label ID="FirstcardPattern_Label" runat="server" Text="方" CssClass="Pattern"></asp:Label>
                    </div>
                    <div id="card1WordDown" class="cardWordDown cardWor">   
                        <asp:Label ID="FirstcardWordDown" runat="server" Text="下" CssClass="Word"></asp:Label>
                    </div>
                </div>
            
                <div class="Result">
                    <asp:Label ID="Result" runat="server" Text="＝" CssClass="Resultword"></asp:Label>
                </div>

                <div id="card2" class="card Seccard">   
                    <div id="card2WordUp" class="cardWordUp cardWor">
                        <asp:Label ID="SecondcardWordUp" runat="server" Text="上" CssClass="Word"></asp:Label>
                    </div>
                    <div id ="card2Pattern" class="cardPattern">   
                        <asp:Label ID="SecondCardPattern_Label" runat="server" Text="方" CssClass="Pattern"></asp:Label>
                    </div>
                    <div id="card2WordDown" class="cardWordDown cardWor">   
                        <asp:Label ID="SecondcardWordDown" runat="server" Text="下" CssClass="Word"></asp:Label>
                    </div>
                </div>
            </div>
            
            <div class="banner-operate">
                <div class="banner-botton">
                    <asp:Button ID="Shuffle_Button" runat="server" Text="重新洗牌" with="" OnClick="Shuffle_Button_Click" />
                    <asp:Button ID="DrawAndSpecificSize_Button" runat="server" Text="抽牌比大小" OnClick="DrawAndSpecificSize_Button_Click" />
                </div>
                <div class="banner-count">
                    未翻牌數剩餘：<asp:Label ID="UnflippedsCount_Label" runat="server" Text="Label" CssClass ="UnflippedsCount"></asp:Label>
                    <br/>
                    已翻牌數剩餘：<asp:Label ID="flippedsCount_Label" runat="server" Text="Label" CssClass ="flippedsCount"></asp:Label>
                </div>
            </div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="" CssClass="Word"></asp:Label>
    </form>

    <script>  

    </script>

</body>
</html>
