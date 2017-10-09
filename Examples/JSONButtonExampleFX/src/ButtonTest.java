import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import javafx.application.Application;
import javafx.event.EventHandler;
import javafx.scene.Group;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.effect.DropShadow;
import javafx.scene.input.MouseEvent;
import javafx.scene.layout.HBox;
import javafx.scene.layout.VBox;
import javafx.stage.Stage;

import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.Scanner;

public class ButtonTest extends Application {

	DropShadow shadow = new DropShadow();
	Label label = new Label();
	
	@Override
	public void start(Stage primaryStage) throws Exception {

		Scene scene = new Scene(new Group());
		primaryStage.setTitle("Test af");
		primaryStage.setWidth(400);
		primaryStage.setHeight(400);

		VBox vbox = new VBox();
		vbox.setLayoutX(20);
		vbox.setLayoutY(20);

		String jsonFromFile = "";

		try(Scanner scan = new Scanner(Files.newInputStream(Paths.get("fake_json.txt"))))
		{
			while(scan.hasNext())
			{
				jsonFromFile += scan.nextLine();
			}
		}

		GsonBuilder builder = new GsonBuilder();
		Gson gsonParser = builder.create();

		ButtonData buttonData = gsonParser.fromJson(jsonFromFile, ButtonData.class);

		for(WinButton button : buttonData.getList())
		{
			Button button1 = new Button();
			button1.setText(button.displayName);

			//button clicked, button gets shadow
			button1.addEventHandler(MouseEvent.MOUSE_CLICKED,
					new EventHandler<MouseEvent>() {
						public void handle(MouseEvent e) {
							button1.setEffect(shadow);
							label.setText("" + button.ID);
						}
					});
			//other button clicked, lose shadow
			button1.addEventHandler(MouseEvent.MOUSE_CLICKED,
					new EventHandler<MouseEvent>() {
						@Override public void handle(MouseEvent e) {
							button1.setEffect(null);
						}
					});

			HBox box = new HBox();
			box.getChildren().add(button1);
			box.getChildren().add(label);
			box.setSpacing(10);

			vbox.getChildren().add(box);
		}


		vbox.setSpacing(10);
		((Group)scene.getRoot()).getChildren().add(vbox);

		primaryStage.setScene(scene);
		primaryStage.show();
		
	}

	public static void main(String[] args) {

		launch(args);
	}
}
