using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    
    //XML selection
    [SerializeField] private string _fileName, _people, _NPC, _name, _text, _choice, _answer, _first, _second, _third, _fourth;
    
    //Text fields
    [SerializeField] private Text _nameText;
    [SerializeField] private Text _textText;
    [SerializeField] private Text _choiceText;
    
    //Selection
    [SerializeField] private bool _person;
    [SerializeField] private bool _answerSelected;
    [SerializeField] private int _selectedAnswer;
    
    
    private List<Dictionary<string, string>> _allTextDic;
    private Dictionary<string, string> _dic;
    
    private void Start()
    {
        _allTextDic = parseFile();
    }

    private void Update()
    {   
        if (_person)
        {
            _dic = _allTextDic[1];
            _nameText.text = _dic[_name];
            _textText.text = _dic[_text];
            _choiceText.text = _dic[_choice];
            
            switch (_selectedAnswer)
            {
                case 1:
                    _textText.text = _dic[_answer + "1"];
                    _choiceText.text = "";
                    break;
                case 2:
                    _textText.text = _dic[_answer + "2"];
                    _choiceText.text = "";
                    break;
                case 3:
                    _textText.text = _dic[_answer + "3"];
                    _choiceText.text = "";
                    break;
                case 4:
                    _textText.text = _dic[_answer + "4"];
                    _choiceText.text = "";
                    break;
            }
            
        }
        else
        {
            _dic = _allTextDic[0];
            _nameText.text = _dic[_name];
            _textText.text = _dic[_text];
            _choiceText.text = _dic[_choice];

            switch (_selectedAnswer)
            {
                case 1:
                    _textText.text = _dic[_answer + "1"];
                    _choiceText.text = "";
                    break;
                case 2:
                    _textText.text = _dic[_answer + "2"];
                    _choiceText.text = "";
                    break;
                case 3:
                    _textText.text = _dic[_answer + "3"];
                    _choiceText.text = "";
                    break;
                case 4:
                    _textText.text = _dic[_answer + "4"];
                    _choiceText.text = "";
                    break;
            }

        }
        
        //Controls
        //Select answer
        if (Input.GetKeyDown(KeyCode.Alpha1) && _answerSelected == false)
        {
            _selectedAnswer = 1;
            _answerSelected = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && _answerSelected == false)
        {
            _selectedAnswer = 2;
            _answerSelected = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && _answerSelected == false)
        {
            _selectedAnswer = 3;
            _answerSelected = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && _answerSelected == false)
        {
            _selectedAnswer = 4;
            _answerSelected = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            _selectedAnswer = 0;
            _answerSelected = false;
        }
        
        //Change person
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _person = !_person;
            _selectedAnswer = 0;
            _answerSelected = false;
        }
        
    }


    public List<Dictionary<string, string>> parseFile()
    {
        TextAsset txtXmlAsset = Resources.Load<TextAsset>(_fileName);
        var doc = XDocument.Parse(txtXmlAsset.text);

        var allDict = doc.Element(_people).Elements(_NPC);
        List<Dictionary<string, string>> allTextDic = new List<Dictionary<string, string>>();
        
        foreach (var oneDict in allDict)
        {
            
            var string1 = oneDict.Elements(_name);
            XElement nameElement1 = string1.ElementAt(0);
            string name1 = nameElement1.ToString().Replace("<" + _name + ">", "").Replace("</" + _name + ">", "");

            var string2 = oneDict.Elements(_text);
            XElement textElement1 = string2.ElementAt(0);
            string text1 = textElement1.ToString().Replace("<" + _text + ">", "").Replace("</" + _text + ">", "");
            
            var string3 = oneDict.Elements(_choice);
            XElement choiceElement0 = string3.ElementAt(0);
            string choice0 = choiceElement0.ToString().Replace("<" + _choice + ">", "").Replace("</" + _choice + ">", "").Replace("</One>", "").Replace("</Two>", "").Replace("</Three>", "").Replace("</Four>", "");
            
            var string4 = oneDict.Elements(_answer).Elements(_first);
            XElement answerElement1 = string4.ElementAt(0);
            string answer1 = answerElement1.ToString().Replace("<" + _first + ">", "").Replace("</" + _first + ">", "");
            
            var string5 = oneDict.Elements(_answer).Elements(_second);
            XElement answerElement2 = string5.ElementAt(0);
            string answer2 = answerElement2.ToString().Replace("<" + _second + ">", "").Replace("</" + _second + ">", "");
            
            var string6 = oneDict.Elements(_answer).Elements(_third);
            XElement answerElement3 = string6.ElementAt(0);
            string answer3 = answerElement3.ToString().Replace("<" + _third + ">", "").Replace("</" + _third + ">", "");
            
            var string7 = oneDict.Elements(_answer).Elements(_fourth);
            XElement answerElement4 = string7.ElementAt(0);
            string answer4 = answerElement4.ToString().Replace("<" + _fourth + ">", "").Replace("</" + _fourth + ">", "");
            
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add(_name, name1);
            dic.Add(_text, text1);
            dic.Add(_choice, choice0);
            dic.Add(_answer + "1", answer1);
            dic.Add(_answer + "2", answer2);
            dic.Add(_answer + "3", answer3);
            dic.Add(_answer + "4", answer4);
            
            allTextDic.Add(dic);
        }

        return allTextDic;
    }
}
