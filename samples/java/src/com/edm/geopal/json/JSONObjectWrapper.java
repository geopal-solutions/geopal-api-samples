package com.edm.geopal.json;

import org.json.JSONException;
import org.json.JSONObject;

public class JSONObjectWrapper extends org.json.JSONObject {
    
    public JSONObjectWrapper(String source) {
        super(source);
    }
    
    public JSONObjectWrapper(JSONObject jo){
        super(jo.toString());
    }

    public String getString(String key, String defaultValue) {
        String result = "";
        try {
            result = this.getString(key);
        } catch (JSONException e) {
            result = defaultValue;
        }
        return result;
    }
    
    
   

}
