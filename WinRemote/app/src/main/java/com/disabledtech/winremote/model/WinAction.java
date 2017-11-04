package com.disabledtech.winremote.model;

/**
 * This class is a model of a window action. It contains
 * all relevant information of an action, such as the
 * command, m_ID and any other pertinent information.
 * <p>
 * Created by aknobloch on 10/7/17.
 */

public class WinAction
{

	private String m_DisplayName;
	private int m_ID;

	/**
	 * Creates a WinAction with the associated display
	 * name and unique ID. This ID should match that
	 * of a button defined on the Windows side, and
	 * cannot be changed after creation.
	 *
	 * @param displayName
	 * @param uniqueID
	 */
	public WinAction(String displayName, int uniqueID)
	{
		setDisplayName(displayName);
		this.m_ID = uniqueID;
	}

	public void setDisplayName(String newName)
	{
		this.m_DisplayName = newName;
	}

	public String getDisplayName()
	{
		return this.m_DisplayName;
	}

	public int getID()
	{
		return this.m_ID;
	}
}
