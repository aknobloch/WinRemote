package com.example.taylor.myapplication;

import android.app.Activity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;


public class MainActivity extends Activity implements View.OnClickListener{

    final TextView tv = (TextView) findViewById(R.id.textView);
    Button b1 = (Button) findViewById(R.id.button1);
    Button b2 = (Button) findViewById(R.id.button2);
    Button b3 = (Button) findViewById(R.id.button3);
    Button b4 = (Button) findViewById(R.id.button4);

    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);}

        public void onClick(View v) {
            tv.setText(b1.getText());
            tv.setText(b2.getText());
            tv.setText(b3.getText());
            tv.setText(b4.getText());
        }
}
