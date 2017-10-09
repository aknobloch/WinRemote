package com.disabledtech.winremote.utils;

import android.content.Context;
import android.util.Log;

/**
 * Utility class for assisting with debug functionality.
 */
public class Debug // TODO rename to log
{
	private static final boolean DEBUG_MODE = true; // TODO ensure false on release

	/**
	 * Logs the given message under the Debug flag. The tag used for this message will be
	 * the class name of the caller with the line number appended.
	 * @param message
	 */
	public static void log(String message)
	{
		if(DEBUG_MODE == false)
		{
			return;
		}

		StackTraceElement[] stackTraceElements = Thread.currentThread().getStackTrace();
		StackTraceElement stackTrace = stackTraceElements[3];

		String className = stackTrace.getClassName()
				.substring(stackTrace.getClassName().lastIndexOf('.') + 1);

		log(className + " (" + stackTrace.getLineNumber() + ")", message);
	}

    /**
     * Logs the given message under the Error flag. The tag used for this message will be
     * the class name of the caller with the line number appended. The debug state
     * of this app will be ignored.
     * @param message
     */
    public static void logError(String message)
    {
        StackTraceElement[] stackTraceElements = Thread.currentThread().getStackTrace();
        StackTraceElement stackTrace = stackTraceElements[3];

        String className = stackTrace.getClassName()
                .substring(stackTrace.getClassName().lastIndexOf('.') + 1);

        logError(className + " (" + stackTrace.getLineNumber() + ")", message);
    }

	/**
	 * Logs the given tag and message under the Debug flag.
	 * @param tag
	 * @param message
	 */
	public static void log(String tag, String message)
	{
		if(DEBUG_MODE == false)
		{
			return;
		}

		Log.d(tag, message);
	}

	/**
	 * Logs the given tag and message under the Error flag.
     * The debug state of the application will be ignored.
	 * @param tag
	 * @param message
	 */
	public static void logError(String tag, String message)
	{
		Log.e(tag, message);
	}
}

