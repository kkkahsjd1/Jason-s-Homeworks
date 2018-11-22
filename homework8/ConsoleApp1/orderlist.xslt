<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:template match="/OrderDetails">
		<html>
			<head>
				<title>My Order</title>
			</head>
			<body>
        <tr  bgcolor="#9acd32">
          <th>订单号</th>
          <th>客户名</th>
          <th>电话号码</th>
          <th>商品</th>
          <th>数量</th>
          <th>单价</th>
          <th>总价</th>
        </tr>
        <xsl:for-each select="OrderDetails">
          <tr>
            <td>
              <xsl:value-of select="No"/>
            </td>
            <td>
              <xsl:value-of select="Client"/>
            </td>
          <td>
              <xsl:value-of select="PhoneNum"/>
            </td>
          <td>
              <xsl:value-of select="Goods"/>
            </td>
          <td>
              <xsl:value-of select="Amount"/>
            </td>
          <td>
              <xsl:value-of select="Price"/>
            </td>
            <td>
              <xsl:value-of select="Total"/>
            </td>
          </tr>
        </xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
