package com.disabledtech.winremote.utils;

import android.content.Context;
import android.content.SharedPreferences;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.HashSet;
import java.util.Set;

/**
 * Convenience class for storage functionality. Utilizes shared preferences.
 */
public class Storage
{
	/**
	 * Save the given boolean value with the associated key.
	 * @param appContext
	 * @param key
	 * @param value
	 */
	public static void saveBoolean(Context appContext, String key, boolean value)
	{
		SharedPreferences sharedPrefs = appContext.getSharedPreferences(key, Context.MODE_PRIVATE);
		SharedPreferences.Editor out = sharedPrefs.edit();

		out.putBoolean(key, value);
		out.commit();
	}

	/**
	 * Loads the boolean associated with the given key. If no shared preference
	 * can be found with the associated key, a FileNotFoundException will be thrown.
	 * If the loading of the boolean is not performed correctly, false will be returned.
	 *
	 * @param appContext
	 * @param key
	 * @return
	 * @throws FileNotFoundException
	 */
	public static boolean getBoolean(Context appContext, String key) throws FileNotFoundException
	{
		SharedPreferences sharedPrefs = appContext.getSharedPreferences(key, Context.MODE_PRIVATE);

		if(sharedPrefs.contains(key) == false)
		{
			throw new FileNotFoundException("Shared preference with key " + key + " doesn't exist.");
		}

		return sharedPrefs.getBoolean(key, false);
	}

	/**
	 * Saves the given Set with the associated key.
	 * @param appContext
	 * @param key
	 * @param selectedAppsPackageNames
	 */
	public static void saveStringSet(Context appContext, String key, Set<String> selectedAppsPackageNames)
	{
		SharedPreferences sharedPrefs = appContext.getSharedPreferences(key, Context.MODE_PRIVATE);
		SharedPreferences.Editor out = sharedPrefs.edit();

		out.putStringSet(key, selectedAppsPackageNames);
		out.commit();
	}

	/**
	 * Fetches and returns the String set from memory. If
	 * no set is found, returns an empty set instead. This is a blocking call.
	 * @return
	 */
	public static HashSet<String> getStringSet(Context appContext, String key)
	{
		SharedPreferences sharedPrefs = appContext.getSharedPreferences(key, Context.MODE_PRIVATE);
		return (HashSet<String>) sharedPrefs.getStringSet(key, new HashSet<String>());
	}

	/**
	 * Gets the log directory for this application. Makes any necessary top
	 * level directories needed.
	 */
	public static File getLogDirectory(Context appContext)
	{
		File directory = new File(appContext.getExternalCacheDir(), "logs");
		directory.mkdirs();

		return directory;
	}

	/**
	 * Clears the log cache associated with this application.
	 */
	public static void clearLogCache(Context context)
	{
		File cacheDir = getLogDirectory(context);

		for(File logFile : cacheDir.listFiles())
		{
			logFile.delete();
		}
	}
}
