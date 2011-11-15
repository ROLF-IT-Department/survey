// JScript File


function onSelectQuestions(num)
{
    var qnum = document.getElementById("quest_num");
    var number_of_questions = qnum.value;

    var id = "sel_" + num;
    var select_quest = document.getElementById(id);
    var selected_quest = select_quest.options[select_quest.selectedIndex].value;
    var i, j;

    for(i=1; i<= number_of_questions; i++)
    {
        var sel_id = "sel_" + i;
        
        var select = document.getElementById(sel_id);
        if (num == i) continue;

        if (selected_quest == "0")
        {
            for(k=0; k<select_quest.options.length; k++)
            {
                FindLostQuestion(select_quest.options[k].value, select_quest.options[k].text);
            }
        }
        else
        {
            for(j=0; j<select.options.length; j++)
                if (selected_quest == select.options[j].value)
                    select.options[j] = null;
            
            for(k=0; k<select_quest.options.length; k++)
            {
                if (select_quest.options[k].value == selected_quest) continue;
                FindLostQuestion(select_quest.options[k].value, select_quest.options[k].text);
            }
        }

    }

}

function FindLostQuestion(value, text)
{
    var qnum = document.getElementById("quest_num");
    var number_of_questions = qnum.value;

    var i, j;
    
    for(i=1; i<= number_of_questions; i++)
    {
        var exist = 0;
        var sel_id = "sel_" + i;
        var select = document.getElementById(sel_id);
        for(j=0; j<select.options.length; j++)
        {
            if (value == select.options[j].value)
                exist = 1; 
        }
        if (exist == 0) select.options[j] = new Option(text, value);
    }

}

function CheckAllQuestions()
{
    var qnum = document.getElementById("quest_num");
    var number_of_questions = qnum.value;
    var i, j;

    for(i=1; i<= number_of_questions; i++)
    {
        var sel_id = "sel_" + i;
        var select = document.getElementById(sel_id);
        if (select.options[select.selectedIndex].value == '0') 
        {
            alert("Внимание! Необходимо заполнить все ответы перед сохранением.");
            return false;
        }
    } 
    return true;
}

function onSaveButtonClick()
{
    var qnum = document.getElementById("quest_num");
    var number_of_questions = qnum.value;

    var i;
    var html = "";
    
    if (CheckAllQuestions() == false) return;

    for(i=1; i<= number_of_questions; i++)
    {
        var sel_id = "sel_" + i;
        var select = document.getElementById(sel_id);
        html += select.options[select.selectedIndex].value + "|" + i + ";";
    }
    
    var argument = html;
    
    //alert(html);
    
    SaveCallback(argument, '');

}


function ClientRefreshCallback(result, context)
{
//    var cnum = document.getElementById("categ_num");
//    var url = "Questions.aspx?cid=" + 11;
//    window.navigate(url);
    //alert(result);
    var span = document.getElementById("sSave");
    span.innerHTML="Спасибо, Ваши ответы сохранены";
    //<asp:Literal ID="lSave" runat="server" Text="Спасибо, Ваши ответы сохранены" Visible="false">

}