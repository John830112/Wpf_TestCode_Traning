using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_TestCode.Utils
{

/*
 * 다중 폼(또는 페이지) (Multi Forms or Pages) 프로그램을 할 때 한 페이지에서 다른 페이지에 있는 함수를 호출해야하는 경우가 있다.
 * 이런 경우에 유용하게 사용할 수 있는 Mediator(중재자) 클래스를 소개하고자 한다. 
 */

    static public class Mediator
    {
        //키와 함수명을 갖는 전역 Dictionary(일종의 리스트)
        static IDictionary<string, List<Action<object>>> pl_dict = new Dictionary<string, List<Action<object>>>();

        //등록 또는 덮어쓰기
        static public void Register(string token, Action<object> callback)
        {
            if (!pl_dict.ContainsKey(token))
            {
                var list = new List<Action<object>>();
                list.Add(callback);
                pl_dict.Add(token, list);
            }
            else
            {
                bool found = false;
                foreach (var item in pl_dict[token])
                    if (item.Method.ToString() == callback.Method.ToString())
                        found = true;
                if (!found)
                    pl_dict[token].Add(callback);
            }
        }

        //해제
        static public void Unregister(string token, Action<object> callback)
        {
            if (pl_dict.ContainsKey(token))
                pl_dict[token].Remove(callback);
        }

        //호출하기
        static public void NotifyColleagues(string token, object args)
        {
            if (pl_dict.ContainsKey(token))
                foreach (var callback in pl_dict[token])
                    callback(args);
        }
    }
}
