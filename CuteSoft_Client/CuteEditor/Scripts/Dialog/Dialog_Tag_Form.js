var OxO86e9=["inp_action","sel_Method","inp_name","inp_id","inp_encode","sel_target","Name","value","name","id","action","method","encoding","application/x-www-form-urlencoded","","target"];var inp_action=Window_GetElement(window,OxO86e9[0x0],true);var sel_Method=Window_GetElement(window,OxO86e9[0x1],true);var inp_name=Window_GetElement(window,OxO86e9[0x2],true);var inp_id=Window_GetElement(window,OxO86e9[0x3],true);var inp_encode=Window_GetElement(window,OxO86e9[0x4],true);var sel_target=Window_GetElement(window,OxO86e9[0x5],true); UpdateState=function UpdateState_Form(){}  ; SyncToView=function SyncToView_Form(){if(element[OxO86e9[0x6]]){ inp_name[OxO86e9[0x7]]=element[OxO86e9[0x6]] ;} ;if(element[OxO86e9[0x8]]){ inp_name[OxO86e9[0x7]]=element[OxO86e9[0x8]] ;} ; inp_id[OxO86e9[0x7]]=element[OxO86e9[0x9]] ; inp_action[OxO86e9[0x7]]=element[OxO86e9[0xa]] ; sel_Method[OxO86e9[0x7]]=element[OxO86e9[0xb]] ;if(element[OxO86e9[0xc]]==OxO86e9[0xd]){ inp_encode[OxO86e9[0x7]]=OxO86e9[0xe] ;} else { inp_encode[OxO86e9[0x7]]=element[OxO86e9[0xc]] ;} ; sel_target[OxO86e9[0x7]]=element[OxO86e9[0xf]] ;}  ; SyncTo=function SyncTo_Form(element){ element[OxO86e9[0x8]]=inp_name[OxO86e9[0x7]] ;if(element[OxO86e9[0x6]]){ element[OxO86e9[0x6]]=inp_name[OxO86e9[0x7]] ;} else {if(element[OxO86e9[0x8]]){ element.removeAttribute(OxO86e9[0x8],0x0) ; element[OxO86e9[0x6]]=inp_name[OxO86e9[0x7]] ;} else { element[OxO86e9[0x6]]=inp_name[OxO86e9[0x7]] ;} ;} ; element[OxO86e9[0x9]]=inp_id[OxO86e9[0x7]] ; element[OxO86e9[0xa]]=inp_action[OxO86e9[0x7]] ; element[OxO86e9[0xb]]=sel_Method[OxO86e9[0x7]] ;try{ element[OxO86e9[0xc]]=inp_encode[OxO86e9[0x7]] ;} catch(e){} ; element[OxO86e9[0xf]]=sel_target[OxO86e9[0x7]] ;if(element[OxO86e9[0xf]]==OxO86e9[0xe]){ element.removeAttribute(OxO86e9[0xf]) ;} ;if(element[OxO86e9[0x6]]==OxO86e9[0xe]){ element.removeAttribute(OxO86e9[0x6]) ;} ;if(element[OxO86e9[0xa]]==OxO86e9[0xe]){ element.removeAttribute(OxO86e9[0xa]) ;} ;}  ;