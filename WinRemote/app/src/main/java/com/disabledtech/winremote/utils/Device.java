package com.disabledtech.winremote.utils;

import android.Manifest;
import android.content.Context;
import android.content.pm.PackageManager;
import android.os.Build;
import android.os.Vibrator;
import android.support.v4.content.ContextCompat;
import android.widget.Toast;

/**
 * Convenience class for performing functionality related to the host device.
 */
public class Device
{

	/**
	 * Vibrates the device for the indicated period of time (in milliseconds)
	 * @param appContext
	 * @param time
	 */
	public static void vibrate(Context appContext, long time)
	{
		Vibrator vibrator = (Vibrator) appContext.getSystemService(Context.VIBRATOR_SERVICE);

		if(vibrator == null) return;

		vibrator.vibrate(time);
	}

	/**
	 * Toasts the given message for the Toast.SHORT period of time.
	 * @param appContext
	 * @param message
	 */
	public static void showToast(Context appContext, String message)
	{
		Toast toast = Toast.makeText(appContext, message, Toast.LENGTH_SHORT);
		toast.show();
	}

	public static boolean hasBluetoothPermissions(Context appContext) {

		if(Build.VERSION.SDK_INT <= Build.VERSION_CODES.M)
		{
			return true; // earlier than marshmallow have implicit access through manifest
		}

		return ContextCompat.checkSelfPermission(appContext,
				Manifest.permission.ACCESS_COARSE_LOCATION) == PackageManager.PERMISSION_GRANTED;
	}
}
