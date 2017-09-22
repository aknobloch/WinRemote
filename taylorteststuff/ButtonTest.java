

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
import javafx.scene.text.Font;
import javafx.stage.Stage;

public class ButtonTest extends Application {
	
	Button button1 = new Button("Copy");
	Button button2 = new Button("Paste");
	DropShadow shadow = new DropShadow();
	Label label = new Label();
	
	@Override
	public void start(Stage primaryStage) throws Exception {
		
		Scene scene = new Scene(new Group());
		primaryStage.setTitle("Test af");
		primaryStage.setWidth(400);
		primaryStage.setHeight(400);
		HBox hbox1 = new HBox();
		HBox hbox2 = new HBox();
		
		VBox vbox = new VBox();
		vbox.setLayoutX(20);
		vbox.setLayoutY(20);
		
		//button clicked, button gets shadow
		button1.addEventHandler(MouseEvent.MOUSE_CLICKED,
				new EventHandler<MouseEvent>() {
					public void handle(MouseEvent e) {
						button1.setEffect(shadow);
						label.setText(("Copy Activated"));
					}
				});
		//other button clicked, lose shadow
		button1.addEventHandler(MouseEvent.MOUSE_CLICKED,
                new EventHandler<MouseEvent>() {
            @Override public void handle(MouseEvent e) {
                button1.setEffect(null);
            }
        });
		
		//button clicked, button gets shadow
				button2.addEventHandler(MouseEvent.MOUSE_CLICKED,
						new EventHandler<MouseEvent>() {
							public void handle(MouseEvent e) {
								button2.setEffect(shadow);
								label.setText(("Paste Activated"));
							}
						});
				//other button clicked, lose shadow
				button2.addEventHandler(MouseEvent.MOUSE_CLICKED,
		                new EventHandler<MouseEvent>() {
		            @Override public void handle(MouseEvent e) {
		                button2.setEffect(null);
		            }
		        });
		
		hbox1.getChildren().add(button1);
		hbox1.getChildren().add(label);
		hbox2.getChildren().add(button2);
		hbox1.setSpacing(10);
		hbox2.setSpacing(10);
		
		vbox.getChildren().add(hbox1);
		vbox.getChildren().add(hbox2);
		vbox.setSpacing(10);
		((Group)scene.getRoot()).getChildren().add(vbox);
		
		primaryStage.setScene(scene);
		primaryStage.show();
		
	}

	public static void main(String[] args) {

		launch(args);
	}
}
