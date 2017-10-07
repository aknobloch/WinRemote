package com.disabledtech.winremote.view;

import android.Manifest;
import android.bluetooth.BluetoothSocket;
import android.content.pm.PackageManager;
import android.os.Bundle;
import android.support.annotation.NonNull;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v4.app.ActivityCompat;
import android.view.View;
import android.support.design.widget.NavigationView;
import android.support.v4.view.GravityCompat;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.ActionBarDrawerToggle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;

import com.disabledtech.winremote.control.BTConnectionClient;
import com.disabledtech.winremote.R;
import com.disabledtech.winremote.interfaces.IServerConnectionListener;
import com.disabledtech.winremote.utils.Device;

import java.io.IOException;
import java.io.OutputStream;

public class MainActivity extends AppCompatActivity
        implements NavigationView.OnNavigationItemSelectedListener, IServerConnectionListener {

    private static final int REQUEST_ACCESS_COARSE_LOCATION = 1; // used to identify permission requests

    private BTConnectionClient connectionClient;
    private BluetoothSocket serverSocket;

    @Override
    protected void onCreate(Bundle savedInstanceState) {

        super.onCreate(savedInstanceState);
        initializeLayout();
        beginServerConnection();
    }

    /**
     * Called when a component of the UI is pressed.
     *
     * @param view
     */
    public void onClick(View view)
    {
        switch(view.getId())
        {
            case R.id.connect :

                getServerConnection();
                break;

            case R.id.send_data :
                
                sendData();
                break;
        }
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {

        int id = item.getItemId();

        // TODO options menu
        switch(id)
        {
            case R.id.action_settings :

                return true;
        }

        return super.onOptionsItemSelected(item);
    }

    @Override
    public boolean onNavigationItemSelected(MenuItem item) {
        // Handle navigation view item clicks here.
        int id = item.getItemId();

        switch(id)
        {
            // TODO templates
        }

        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        drawer.closeDrawer(GravityCompat.START);

        return true;
    }

    @Override
    public void onBackPressed() {

        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);

        // if the template drawer is open, back should just close it
        if (drawer.isDrawerOpen(GravityCompat.START)) {

            drawer.closeDrawer(GravityCompat.START);
            return;
        }

        super.onBackPressed();
    }

    /**
     * Requests bluetooth connection permissions if applicable,
     * and then starts the server connection process.
     *
     */
    private void beginServerConnection() {

        if(Device.hasBluetoothPermissions(this))
        {
            getServerConnection();
            return;
        }

        // TODO display reason for coarse location (needs it to discover BT devices)
        ActivityCompat.requestPermissions(this,
                new String[]{Manifest.permission.ACCESS_COARSE_LOCATION},
                REQUEST_ACCESS_COARSE_LOCATION);
    }

    /**
     * Initializes a {@link BTConnectionClient} and begins the connection
     * process.
     */
    public void getServerConnection() {

        if(connectionClient == null)
        {
            connectionClient = new BTConnectionClient(this);
        }

        connectionClient.connectToServer();
    }


    private void sendData() {

        if(serverSocket == null) {

            Device.showToast(this, "Connection not established.");
            return;
        }

        try
        {
            OutputStream out = serverSocket.getOutputStream();
            out.write(0);

        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    /**
     * Returned after the request permission dialog is given. If permissions
     * were successful, then a server connection will attempt to be established.
     *
     * @param requestCode
     * @param permissions
     * @param grantResults
     */
    @Override
    public void onRequestPermissionsResult(int requestCode, @NonNull String[] permissions, @NonNull int[] grantResults) {

        boolean permissionGranted = grantResults.length > 0 &&
                grantResults[0] == PackageManager.PERMISSION_GRANTED;

        if(permissionGranted == false)
        {
            return; // TODO handle refused connection (prompt and close, likely.) update docs.
        }

        switch(requestCode)
        {
            case REQUEST_ACCESS_COARSE_LOCATION :

                getServerConnection();
                break;
        }
    }

    @Override
    public void serverConnected(BluetoothSocket connectedSocket) {

        serverSocket = connectedSocket;
    }

    @Override
    public void notifyCriticalFailure(SERVER_ERROR_CODE error) {
        // TODO handle communication with user
    }

    @Override
    public void notifyRecoverableFailure(SERVER_ERROR_CODE error) {
        // TODO handle communication with user
    }

    private void initializeLayout() {

        setContentView(R.layout.activity_main);

        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        FloatingActionButton fab = (FloatingActionButton) findViewById(R.id.fab);
        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Snackbar.make(view, "Replace with your own action", Snackbar.LENGTH_LONG)
                        .setAction("Action", null).show();
            }
        });

        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(
                this, drawer, toolbar, R.string.navigation_drawer_open, R.string.navigation_drawer_close);
        drawer.setDrawerListener(toggle);
        toggle.syncState();

        NavigationView navigationView = (NavigationView) findViewById(R.id.nav_view);
        navigationView.setNavigationItemSelectedListener(this);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.main_interface, menu);
        return true;
    }
}
