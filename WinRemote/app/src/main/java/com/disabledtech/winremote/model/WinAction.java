package com.disabledtech.winremote.model;

import com.google.gson.annotations.SerializedName;

/**
 * This class is a model of a window action. It contains
 * all relevant information of an action, such as the
 * command, m_ID and any other pertinent information.
 * <p>
 * Created by aknobloch on 10/7/17.
 */

public class WinAction
{
	@SerializedName("m_ID")
	private int m_ID;

	@SerializedName("m_Template")
	private String m_Template;

	@SerializedName("m_Name")
	private String m_Name;

	@SerializedName("m_SendKeysAciton")
	private String m_SendKeysAction;

	public WinAction()
	{
		// needed by GSON parser
	}

	/**
	 * Creates a WinAction with the associated display
	 * name and unique ID. This ID should match that
	 * of a button defined on the Windows side, and
	 * cannot be changed after creation.
	 */
	public WinAction(int uniqueID, String template, String name, String action)
	{
		this.m_ID = uniqueID;
		this.m_Template = template;
		this.m_Name = name;
		this.m_SendKeysAction = action;
	}

	public int getID()
	{
		return this.m_ID;
	}

	public String getDisplayName()
	{
		return this.m_Name;
	}

	public String getTemplateName()
	{
		return this.m_Template;
	}
}
