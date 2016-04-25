using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;    
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class JsonManager : MonoBehaviour {

    private static GameObject _go_Instance;
    private static JsonManager _s_Instance;

    private ProductData _productData;
    //public JObject jsonTestObject;

    public static JsonManager Instance()
    {
        if(_s_Instance == null)
        {
            if(_go_Instance == null)
            {
                _go_Instance = new GameObject("MAN_Json");
            }

            if(_go_Instance.GetComponent<JsonManager>() == null)
            {
                _go_Instance.AddComponent<JsonManager>();
            }

            _s_Instance = _go_Instance.GetComponent<JsonManager>();

            DontDestroyOnLoad(_go_Instance);
        }

        return _s_Instance;
    }
    void Awake()
    {
        //_productData = JsonConvert.DeserializeObject<ProductData>("[{\"id\":1, \"name\":\"mellby\", \"kind\":\"Chair\", \"price_cents\":27900, \"reviews\":[{\"product_id\":1, \"username\":\"Loretta\", \"body\":\"I could sit in it all day!\", \"is_positive\":true}, {\"product_id\":1, \"username\":\"Bobert\", \"body\":\"I lost my cat in it\", \"is_positive\":false}, {\"product_id\":1, \"username\":\"Elise7849\", \"body\":\"soOooOo comfy\", \"is_positive\":true}]}, {\"id\":2, \"name\":\"kivik\", \"kind\":\"Loveseat\", \"price_cents\":52900, \"reviews\":[{\"product_id\":2, \"username\":\"Gwen and Alex\", \"body\":\"we love this seat. get it? haha\", \"is_positive\":true}, {\"product_id\":2, \"username\":\"Josherator\", \"body\":\"my homies love crashin on dis thing\", \"is_positive\":true}, {\"product_id\":2, \"username\":\"Lovr\", \"body\":\"not big enough for three\", \"is_positive\":false}]}, {\"id\":3, \"name\":\"hemnes\", \"kind\":\"Coffee Table\", \"price_cents\":13900, \"reviews\":[{\"product_id\":3, \"username\":\"Annie Holmes\", \"body\":\"very spill resistant\", \"is_positive\":true}, {\"product_id\":3, \"username\":\"Horton\", \"body\":\"great for those art books you never read\", \"is_positive\":true}]}, {\"id\":4, \"name\":\"klabb\", \"kind\":\"Floor Lamp\", \"price_cents\":8999, \"reviews\":[{\"product_id\":4, \"username\":\"Alice\", \"body\":\"too bright\", \"is_positive\":false}, {\"product_id\":4, \"username\":\"StudyBoy\", \"body\":\"great for reading\", \"is_positive\":true}]}, {\"id\":5, \"name\":\"fredlos\", \"kind\":\"Vase\", \"price_cents\":1999, \"reviews\":[]}, {\"id\":6, \"name\":\"formlig\", \"kind\":\"Vase\", \"price_cents\":999, \"reviews\":[]}]");
        //jsonTestObject = JObject.Parse("[{ 'id':1,'name':'mellby','kind':'Chair','price_cents':27900,'reviews':[{'product_id':1,'username':'Loretta','body':'I could sit in it all day!','is_positive':true}}]");
        //jsonTestObject = JObject.Parse("[{\"id\":1, \"name\":\"mellby\", \"kind\":\"Chair\", \"price_cents\":27900, \"reviews\":[{\"product_id\":1, \"username\":\"Loretta\", \"body\":\"I could sit in it all day!\", \"is_positive\":true}, {\"product_id\":1, \"username\":\"Bobert\", \"body\":\"I lost my cat in it\", \"is_positive\":false}, {\"product_id\":1, \"username\":\"Elise7849\", \"body\":\"soOooOo comfy\", \"is_positive\":true}]}, {\"id\":2, \"name\":\"kivik\", \"kind\":\"Loveseat\", \"price_cents\":52900, \"reviews\":[{\"product_id\":2, \"username\":\"Gwen and Alex\", \"body\":\"we love this seat. get it? haha\", \"is_positive\":true}, {\"product_id\":2, \"username\":\"Josherator\", \"body\":\"my homies love crashin on dis thing\", \"is_positive\":true}, {\"product_id\":2, \"username\":\"Lovr\", \"body\":\"not big enough for three\", \"is_positive\":false}]}, {\"id\":3, \"name\":\"hemnes\", \"kind\":\"Coffee Table\", \"price_cents\":13900, \"reviews\":[{\"product_id\":3, \"username\":\"Annie Holmes\", \"body\":\"very spill resistant\", \"is_positive\":true}, {\"product_id\":3, \"username\":\"Horton\", \"body\":\"great for those art books you never read\", \"is_positive\":true}]}, {\"id\":4, \"name\":\"klabb\", \"kind\":\"Floor Lamp\", \"price_cents\":8999, \"reviews\":[{\"product_id\":4, \"username\":\"Alice\", \"body\":\"too bright\", \"is_positive\":false}, {\"product_id\":4, \"username\":\"StudyBoy\", \"body\":\"great for reading\", \"is_positive\":true}]}, {\"id\":5, \"name\":\"fredlos\", \"kind\":\"Vase\", \"price_cents\":1999, \"reviews\":[]}, {\"id\":6, \"name\":\"formlig\", \"kind\":\"Vase\", \"price_cents\":999, \"reviews\":[]}]");
        //_productData = JsonConvert.DeserializeObject<ProductData>(jsonObject);
    }

    void Start()
    {

    }

	// Update is called once per frame
	void Update ()
    {
        //Debug.Log(_productData.ProductList[0].Name);
        
	}

     
}
