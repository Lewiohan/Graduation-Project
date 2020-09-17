public  var level_Name:      String;
public  var texture_loading : Texture;
private var AsOp:         AsyncOperation;
private var loading_progress: float = 0;
private var Round_load;    

function Start () {

AsOp=Application.LoadLevelAsync(level_Name); // загружаем уровень
	
AsOp.allowSceneActivation=false; // запрещаем перелючаться на загруженный уровень сразу после загрузки.

}

function OnGUI(){

if(loading_progress <= 100){
loading_progress += Time.deltaTime*25;
Round_load = Mathf.RoundToInt(loading_progress); // округляем число до целого.
}


if(AsOp.progress == 0.9 && Round_load == 100){   // если загрузка завершена тогда
	GUI.Label(new Rect(Screen.width/2-100,Screen.height/2+200,300,300),"Нажмите на любую клавишу");
}


if(AsOp != null){ // если загрузка выполняется тогда
	GUI.Label (Rect (Screen.width/2-65,Screen.height/2+220,Screen.width,Screen.height),"Загрузка: " + Round_load); // загрузка в процентах
	GUI.DrawTexture(Rect(0,Screen.height-60,loading_progress/100*Screen.width,40), texture_loading); // Рисуем текстуру. Ширина начала ; Высота начала; Ширина; Высота; Текстура;

}
	


}