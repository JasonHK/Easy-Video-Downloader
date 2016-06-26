<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意:  以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.DownloadButton = New System.Windows.Forms.Button()
        Me.UpdateButton = New System.Windows.Forms.Button()
        Me.AboutButton = New System.Windows.Forms.Button()
        Me.LinkTextBox = New System.Windows.Forms.TextBox()
        Me.OutputTextBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'DownloadButton
        '
        Me.DownloadButton.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.DownloadButton.Location = New System.Drawing.Point(10, 45)
        Me.DownloadButton.Name = "DownloadButton"
        Me.DownloadButton.Size = New System.Drawing.Size(150, 150)
        Me.DownloadButton.TabIndex = 2
        Me.DownloadButton.Text = "下載影片"
        Me.DownloadButton.UseVisualStyleBackColor = True
        '
        'UpdateButton
        '
        Me.UpdateButton.Location = New System.Drawing.Point(10, 200)
        Me.UpdateButton.Name = "UpdateButton"
        Me.UpdateButton.Size = New System.Drawing.Size(150, 35)
        Me.UpdateButton.TabIndex = 0
        Me.UpdateButton.TabStop = False
        Me.UpdateButton.Text = "檢查更新"
        Me.UpdateButton.UseVisualStyleBackColor = True
        '
        'AboutButton
        '
        Me.AboutButton.Location = New System.Drawing.Point(10, 240)
        Me.AboutButton.Name = "AboutButton"
        Me.AboutButton.Size = New System.Drawing.Size(150, 35)
        Me.AboutButton.TabIndex = 0
        Me.AboutButton.TabStop = False
        Me.AboutButton.Text = "關於程式"
        Me.AboutButton.UseVisualStyleBackColor = True
        '
        'LinkTextBox
        '
        Me.LinkTextBox.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkTextBox.Location = New System.Drawing.Point(10, 10)
        Me.LinkTextBox.Name = "LinkTextBox"
        Me.LinkTextBox.Size = New System.Drawing.Size(515, 26)
        Me.LinkTextBox.TabIndex = 1
        '
        'OutputTextBox
        '
        Me.OutputTextBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.OutputTextBox.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OutputTextBox.Location = New System.Drawing.Point(170, 45)
        Me.OutputTextBox.Multiline = True
        Me.OutputTextBox.Name = "OutputTextBox"
        Me.OutputTextBox.ReadOnly = True
        Me.OutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.OutputTextBox.Size = New System.Drawing.Size(355, 230)
        Me.OutputTextBox.TabIndex = 0
        Me.OutputTextBox.TabStop = False
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(534, 282)
        Me.Controls.Add(Me.OutputTextBox)
        Me.Controls.Add(Me.LinkTextBox)
        Me.Controls.Add(Me.AboutButton)
        Me.Controls.Add(Me.UpdateButton)
        Me.Controls.Add(Me.DownloadButton)
        Me.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.Text = "簡易影片下載器"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DownloadButton As System.Windows.Forms.Button
    Friend WithEvents UpdateButton As System.Windows.Forms.Button
    Friend WithEvents AboutButton As System.Windows.Forms.Button
    Friend WithEvents LinkTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OutputTextBox As System.Windows.Forms.TextBox

End Class
