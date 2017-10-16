package com.disabledtech.winremote.utils;

/**
 * Null safe class for various string operations.
 */
public class StringUtil
{
	/**
	 * Determines if the first string equals the second.
	 * If both are null, true.
	 * If one is null, false.
	 *
	 * @param firstString
	 * @param secondString
	 * @return
	 */
	public static boolean equals(String firstString, String secondString)
	{
		if(firstString == null && secondString == null)
		{
			return true;
		}

		if(firstString == null)
		{
			return false;
		}

		if(secondString == null)
		{
			return false;
		}

		return firstString.equals(secondString);
	}

	/**
	 * Determines if the second string is contained within the first.
	 * If the first string is null, then it is determined as false.
	 * If the second string is null (but first is not) it is true.
	 *
	 * @param firstString
	 * @param secondString
	 * @return
	 */
	public static boolean contains(String firstString, String secondString)
	{
		if (firstString == null)
		{
			return false;
		}

		if (secondString == null)
		{
			return true;
		}

		return firstString.contains(secondString);
	}

	/**
	 * Compares the first string to the second.
	 * If both null, returns 0
	 * Otherwise, null is considered lower lexicographically.
	 *
	 * @param firstString
	 * @param secondString
	 * @return
	 */
	public static int compareTo(String firstString, String secondString)
	{
		if (firstString == null && secondString == null)
		{
			return 0;
		}

		if (firstString == null)
		{
			return -1;
		}

		if(secondString == null)
		{
			return 1;
		}

		return firstString.compareTo(secondString);
	}

	/**
	 * Returns the lowercase version of the string.
	 * If null, returns null.
	 *
	 * @param firstString
	 * @return
	 */
	public static String toLowerCase(String firstString)
	{
		if(firstString == null)
		{
			return null;
		}

		return firstString.toLowerCase();
	}
}
