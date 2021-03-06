﻿Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.Utils.Win
Imports DevExpress.XtraEditors

Namespace PopupContainerWithOKButton
	Partial Public Class MainForm
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub checkEditShowCustomButton_Properties_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles checkEditShowCustomButton.Properties.EditValueChanged
			popupContainerEditCustomButtonForTest.Properties.ShowCustomButton = CBool(checkEditShowCustomButton.EditValue)
			Dim currentPopupWindow As Control = (TryCast(popupContainerEditCustomButtonForTest, IPopupControl)).PopupWindow
			If currentPopupWindow IsNot Nothing Then
				currentPopupWindow.Dispose()
			End If
		End Sub

		Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			checkEditShowCustomButton.EditValue = True
		End Sub


		Private Sub popupContainerEditCustomButtonForTest_Properties_QueryResultValue(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.QueryResultValueEventArgs) Handles popupContainerEditCustomButtonForTest.Properties.QueryResultValue
			e.Value = buttonEditSample.EditValue
		End Sub

		Private Sub popupContainerEditCustomButtonForTest_Properties_CustomButtonClick(ByVal sender As Object, ByVal e As PopupContainerCustomButtonControl.EventsArgsCustomButton) Handles popupContainerEditCustomButtonForTest.Properties.CustomButtonClick
			If e.CustomButton.Text = "Ok" Then
				label1.Text = "Status: button Ok is pressed"
			ElseIf e.CustomButton.Text = "Close" Then
				label1.Text = "Status: button Close is pressed"
			Else
				label1.Text = "Status: " & e.CustomButton.Tag.ToString()
			End If
		End Sub
	End Class
End Namespace
