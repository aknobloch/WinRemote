package com.disabledtech.winremote.model;

import android.content.Context;
import android.widget.Button;

/**
 * This class is a simple wrapper around the AppCompatButton to
 * associate a WinAction with said button. It automatically
 * sets the display name and provides convenience methods.
 * <p>
 * Created by aknobloch on 10/10/2017.
 */

public class WinActionButton extends android.support.v7.widget.AppCompatButton
{
	private WinAction m_Action;

	public WinActionButton(Context context, WinAction action)
	{
		super(context);
		m_Action = action;
		this.setText(action.getDisplayName());
	}

	public String getDisplayName()
	{
		return (String) this.getText();
	}

	/**
	 * @return the unique database ID for the action associated with this button.
	 */
	public int getActionID()
	{
		return m_Action.getID();
	}

	public WinAction getWinAction()
	{
		return m_Action;
	}
}
