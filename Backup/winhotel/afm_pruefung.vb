Public Class afm_pruefung

    Function ist_afm_ok(ByVal afm As String) As Boolean
        Try
            If afm.Length = 9 AndAlso CType(afm, Integer) Then
                Dim i As Integer
                Dim index As Int16 = 9
                Dim sum As Integer = 0
                For i = 0 To afm.Length - 2
                    'iSum = iSum + Val(Mid(sAFM, i, 1)) * (2 ^ (Len(sAFM) - i))
                    sum = afm(i).ToString * (2 ^ (afm.Length - (i + 1))) + sum
                    'sum = afm(i).ToString * index + sum
                    index = index - 1


                Next

                If sum Mod 11 = afm(8).ToString Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Catch ex As InvalidCastException

            Return False
        End Try
        

    End Function
   
End Class
