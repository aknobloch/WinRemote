package com.example.aknobloch.myapplication;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.EditText;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    public void submitButtonPressed(View view)
    {
        TextView display = (TextView) findViewById(R.id.displayText);
        EditText enterField = (EditText) findViewById(R.id.editText);

        String enterFieldText = enterField.getText().toString();
        display.setText(enterFieldText);
    }
}
