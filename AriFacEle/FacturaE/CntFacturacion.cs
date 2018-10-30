using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AriFacElec;
using AriGasolModel;
using AriTaxiModel;
using DatosFacturaLib;

namespace FacturaE
{
    public class CntFacturacion
    {
        ArigesContext ctx1;

        //public Facturae GenerarFactura(Empresa empresa, Facturas_cab factura )

        public Facturae GenerarFacturaGdes(Cau_FIN_FACEInvoiceHeader gdesHeader, GdesModelo ctx0)
        {
            Facturae facE = new Facturae();
            FileHeaderGdes(facE, gdesHeader);
            PartiesGdes(facE, gdesHeader);
            InvoicesGdes(facE, gdesHeader, ctx0);
            return facE;
        }

        public Facturae GenerarFacturaAriGes(Scafac factura, ArigesContext ctx0, string numCuenta, FacturaEntity ctx1)
        {
            Sparam empresa = (from emp in ctx0.Sparams
                              select emp).FirstOrDefault<Sparam>();
            Empresa emp2 = (from e in ctx1.Empresas
                            where e.Cif == empresa.Cifempre
                            select e).FirstOrDefault<Empresa>();
            
            Facturae facE = new Facturae();
            FileHeaderAriGes(facE, factura, ctx0);
            PartiesAriGes(facE, empresa, factura, emp2, ctx0);
            InvoicesAriGes(facE, factura, numCuenta, ctx0);
            return facE;
        }
        
        public Facturae GenerarFacturaAriGasol(Schfac factura, AriGasolContext ctx2, string numCuenta)
        {
            Sempre empresa = (from emp in ctx2.Sempres
                              select emp).FirstOrDefault<Sempre>();

            Facturae facE = GenerateAriGasolInvoice31(empresa, factura, numCuenta);
            return facE;
        }

        #region AriTAxi
        
        public Facturae GenerarFacturaAriTaxi(Scafaccli factura, AriTaxiContext ctx0, string numCuenta)
        {
            SparamTaxi empresa = (from emp in ctx0.SparamTaxis
                                  select emp).FirstOrDefault<SparamTaxi>();
            
            Facturae facE = new Facturae();
            FileHeaderAriTaxi(facE, factura, ctx0);
            PartiesAriTaxi(facE, empresa, factura, ctx0);
            InvoicesAriTaxi(facE, factura, numCuenta, ctx0);
            return facE;
        }
        
        private void FileHeaderAriTaxi(Facturae fcte, Scafaccli factura, AriTaxiContext ctx0)
        {
            // File Header.
            fcte.FileHeader = new FileHeaderType();
            fcte.FileHeader.SchemaVersion = SchemaVersionType.Item32; // 3.1 Version
            fcte.FileHeader.Modality = ModalityType.I; // Individual
            fcte.FileHeader.InvoiceIssuerType = InvoiceIssuerTypeType.EM; // Issuer is "EMISOR"
            
            // Constructing batch identifier = Issuer nif + invoice serial + invoice number + invoice date
            string letrafac = getLetraSerie(factura.Codtipom, ctx0);
            string batchIdentifier = String.Format("{0}{1}{2:0000000}{3:yyyMMdd}",
                factura.Nifclien,
                letrafac,
                factura.Numfactu,
                factura.Fecfactu);
            fcte.FileHeader.Batch = new BatchType();
            fcte.FileHeader.Batch.BatchIdentifier = batchIdentifier;
            fcte.FileHeader.Batch.InvoicesCount = 1; // Modality is individual 1 invoice per file
            
            // all amounts have the same value
            fcte.FileHeader.Batch.TotalInvoicesAmount = new AmountType();
            fcte.FileHeader.Batch.TotalInvoicesAmount.TotalAmount = new DoubleTwoDecimalType((double)factura.Totalfac);
            fcte.FileHeader.Batch.TotalOutstandingAmount = new AmountType();
            fcte.FileHeader.Batch.TotalOutstandingAmount.TotalAmount = new DoubleTwoDecimalType((double)factura.Totalfac);
            fcte.FileHeader.Batch.TotalExecutableAmount = new AmountType();
            fcte.FileHeader.Batch.TotalExecutableAmount.TotalAmount = new DoubleTwoDecimalType((double)factura.Totalfac);
            fcte.FileHeader.Batch.InvoiceCurrencyCode = CurrencyCodeType.EUR; // invoices is in euros
        }
        
        private void PartiesAriTaxi(Facturae fcte, SparamTaxi empresa, Scafaccli factura, AriTaxiContext ctx1)
        {
            string aux = "";
            // TODO: Person type code must be obtained from NIF
            fcte.Parties = new PartiesType();
            fcte.Parties.SellerParty = new BusinessType();
            fcte.Parties.SellerParty.TaxIdentification = new TaxIdentificationType();
            fcte.Parties.SellerParty.TaxIdentification.PersonTypeCode = PersonTypeCodeType.J;
            fcte.Parties.SellerParty.TaxIdentification.ResidenceTypeCode = ResidenceTypeCodeType.R;
            string nif = empresa.Cifempre;
            if (nif.Length > 2)
            {
                if (nif.Substring(0, 2) != "ES")
                    nif = "ES" + nif;
            }
            fcte.Parties.SellerParty.TaxIdentification.TaxIdentificationNumber = nif;
            
            //Ciudade ciu = (from c in ctx1.Ciudades
            //               where c.Codposta == empresa.Codposta
            //               select c).FirstOrDefault<Ciudade>();
            LegalEntityType legalEntity = new LegalEntityType();
            legalEntity.CorporateName = empresa.Nomempre;
            AddressType address = new AddressType();
            address.Address = empresa.Domempre;
            address.PostCode = empresa.Codpobla;
            address.Town = empresa.Pobempre;
            address.Province = empresa.Proempre;
            address.CountryCode = CountryType.ESP;
            legalEntity.Item = address;
            
            fcte.Parties.SellerParty.Item = legalEntity;
            
            Scliente cliente = (from c in ctx1.Sclientes
                                where c.Codclien == factura.Codclien
                                select c).FirstOrDefault<Scliente>();
            fcte.Parties.BuyerParty = new BusinessType();
            fcte.Parties.BuyerParty.TaxIdentification = new TaxIdentificationType();
            fcte.Parties.BuyerParty.TaxIdentification.PersonTypeCode = PersonTypeCodeType.J;
            fcte.Parties.BuyerParty.TaxIdentification.ResidenceTypeCode = ResidenceTypeCodeType.R;
            fcte.Parties.BuyerParty.TaxIdentification.TaxIdentificationNumber = cliente.Nifclien;

            if (cliente.OrganoGestor != null && cliente.OrganoGestor != "")
            {
            }
            
            // Hay que controlar en el caso de clientes de administración pública
            // montar la información de oficina contable, organo gestor y unidad tramitadora.
            // buscamos el cliente en FActuraE para ver si contiene las columnas
            FacturaEntity ctx4 = new FacturaEntity("FacturaEntity");
            Cliente cFacturae = (from c in ctx4.Clientes
                                 where c.CodTeletaxi == cliente.Codclien
                                 select c).FirstOrDefault<Cliente>();
            if (cFacturae != null)
            {
                // Comprobamos que tiene los códigos para operar en Adm. Pública
                if (cFacturae.OrganoGestorCodigo != null && cFacturae.OrganoGestorCodigo != "")
                {
                    // Ahora hay que leer la unidad para conocer sus códigos
                    Unidad uAdm = (from u in ctx4.Unidads
                                   where u.OficinaContableCodigo == cFacturae.OficinaContableCodigo &&
                                         u.OrganoGestorCodigo == cFacturae.OrganoGestorCodigo &&
                                         u.UnidadTramitadoraCodigo == cFacturae.UnidadTramitadoraCodigo
                                   select u).FirstOrDefault<Unidad>();
                    
                    // De momento montamos todas las direcciones como comunes
                    address = new AddressType();
                    if (cliente.Domclien.Length > 80)
                        aux = cliente.Domclien.Substring(0, 80);
                    else
                        aux = cliente.Domclien;
                    address.Address = aux;
                    // 9
                    if (cliente.Codpobla.Length > 9)
                        aux = cliente.Codpobla.Substring(0, 80);
                    else
                        aux = cliente.Codpobla;
                    address.PostCode = aux;
                    // 50
                    if (cliente.Pobclien.Length > 50)
                        aux = cliente.Pobclien.Substring(0, 50);
                    else
                        aux = cliente.Pobclien;
                    address.Town = aux;
                    // 20
                    if (cliente.Proclien.Length > 20)
                        aux = cliente.Proclien.Substring(0, 20);
                    else
                        aux = cliente.Proclien;
                    address.Province = aux;

                    address.CountryCode = CountryType.ESP;

                    // Ahora montamos las diferentes unidades administrativas (4) 
                    // Siempre a partir del cliente
                    if (cFacturae.OrganoProponente != null && cFacturae.OrganoProponente != "")
                    {
                        fcte.Parties.BuyerParty.AdministrativeCentres = new AdministrativeCentreType[4];
                    }
                    else
                    {
                        fcte.Parties.BuyerParty.AdministrativeCentres = new AdministrativeCentreType[3];
                    }
                    
                    AdministrativeCentreType admCenter = new AdministrativeCentreType();
                    // Organo gestor
                    admCenter.CentreCode = cFacturae.OrganoGestorCodigo;
                    admCenter.RoleTypeCode = RoleTypeCodeType.Item02;
                    admCenter.RoleTypeCodeSpecified = true;
                    admCenter.Item = address;
                    admCenter.CentreDescription = cliente.Nomclien;
                    fcte.Parties.BuyerParty.AdministrativeCentres[0] = admCenter;
                    // Unidad tramitadora
                    admCenter = new AdministrativeCentreType();
                    admCenter.CentreCode = cFacturae.UnidadTramitadoraCodigo;
                    admCenter.RoleTypeCode = RoleTypeCodeType.Item03;
                    admCenter.RoleTypeCodeSpecified = true;
                    admCenter.Item = address;
                    admCenter.CentreDescription = cliente.Nomclien;
                    fcte.Parties.BuyerParty.AdministrativeCentres[1] = admCenter;
                    // oficina contable
                    admCenter = new AdministrativeCentreType();
                    admCenter.CentreCode = cFacturae.OficinaContableCodigo;
                    admCenter.RoleTypeCode = RoleTypeCodeType.Item01;
                    admCenter.RoleTypeCodeSpecified = true;
                    admCenter.Item = address;
                    admCenter.CentreDescription = cliente.Nomclien;
                    fcte.Parties.BuyerParty.AdministrativeCentres[2] = admCenter;
                    if (cFacturae.OrganoProponente != null && cFacturae.OrganoProponente != "")
                    {
                        // organo proponente
                        admCenter = new AdministrativeCentreType();
                        admCenter.CentreCode = cFacturae.OrganoProponente;
                        admCenter.RoleTypeCode = RoleTypeCodeType.Item04;
                        admCenter.RoleTypeCodeSpecified = true;
                        admCenter.Item = address;
                        admCenter.CentreDescription = cliente.Nomclien;
                        fcte.Parties.BuyerParty.AdministrativeCentres[3] = admCenter;
                    }
                }
            }
            
            legalEntity = new LegalEntityType();
            if (cliente.Nomcomer == null || cliente.Nomcomer == "")
            {
                legalEntity.CorporateName = cliente.Nomclien;
            }
            else
            {
                legalEntity.CorporateName = cliente.Nomcomer;
            }
            
            address = new AddressType();
            if (cliente.Domclien.Length > 80)
                aux = cliente.Domclien.Substring(0, 80);
            else
                aux = cliente.Domclien;
            address.Address = aux;
            // 9
            if (cliente.Codpobla.Length > 9)
                aux = cliente.Codpobla.Substring(0, 80);
            else
                aux = cliente.Codpobla;
            address.PostCode = aux;
            // 50
            if (cliente.Pobclien.Length > 50)
                aux = cliente.Pobclien.Substring(0, 50);
            else
                aux = cliente.Pobclien;
            address.Town = aux;
            // 20
            if (cliente.Proclien.Length > 20)
                aux = cliente.Proclien.Substring(0, 20);
            else
                aux = cliente.Proclien;
            address.Province = aux;
            address.CountryCode = CountryType.ESP;
            legalEntity.Item = address;
            
            fcte.Parties.BuyerParty.Item = legalEntity;
        }
        
        private void InvoicesAriTaxi(Facturae fcte, Scafaccli factura, string numCuenta, AriTaxiContext ctx0)
        {
            fcte.Invoices = new InvoiceType[1]; // One invoice only
            InvoiceType inv = new InvoiceType();
            inv.InvoiceHeader = new InvoiceHeaderType();
            inv.InvoiceHeader.InvoiceNumber = factura.Numfactu.ToString();
            inv.InvoiceHeader.InvoiceSeriesCode = getLetraSerie(factura.Codtipom, ctx0).ToString();
            inv.InvoiceHeader.InvoiceClass = InvoiceClassType.OO; // TODO: We are fixing invoice class value (perhaps incorrect)
            
            inv.InvoiceIssueData = new InvoiceIssueDataType();
            inv.InvoiceIssueData.IssueDate = factura.Fecfactu;
            if (factura.Fecdesde != null && factura.Fechasta != null)
            {
                inv.InvoiceIssueData.InvoicingPeriod = new PeriodDates();
                inv.InvoiceIssueData.InvoicingPeriod.StartDate = factura.Fecdesde;
                inv.InvoiceIssueData.InvoicingPeriod.EndDate = factura.Fechasta;
            }

            inv.InvoiceIssueData.InvoiceCurrencyCode = CurrencyCodeType.EUR; // fixed euros
            inv.InvoiceIssueData.TaxCurrencyCode = CurrencyCodeType.EUR; // taxes in euros too.
            inv.InvoiceIssueData.LanguageName = LanguageCodeType.es; // always in Spanish
            
            inv.TaxesOutputs = new TaxOutputType[3];
            int i = 0; // index of TaxesOutputs (begins cero)
            double grossAmount = 0;
            double totalTaxOutputs = 0;
            TaxOutputType taxOutput; // each tax output
            // AriGes invoice could have 3 diferent fixed taxes

            #region[IVA]
            
            try
            {
                taxOutput = new TaxOutputType();
                taxOutput.TaxTypeCode = TaxTypeCodeType.Item01;
                taxOutput.TaxRate = new DoubleTwoDecimalType((double)factura.Porciva1);
                taxOutput.TaxableBase = new AmountType();
                taxOutput.TaxableBase.TotalAmount = new DoubleTwoDecimalType((double)factura.Baseimp1);
                grossAmount += (double)factura.Baseimp1;
                taxOutput.TaxAmount = new AmountType();
                taxOutput.TaxAmount.TotalAmount = new DoubleTwoDecimalType((double)factura.Imporiv1);
                totalTaxOutputs += (double)factura.Imporiv1;
                inv.TaxesOutputs[0] = taxOutput;
            }
            catch (InvalidOperationException ioe)
            {
            }
            try
            {
                taxOutput = new TaxOutputType();
                taxOutput.TaxTypeCode = TaxTypeCodeType.Item01;
                taxOutput.TaxRate = new DoubleTwoDecimalType((double)factura.Porciva2);
                taxOutput.TaxableBase = new AmountType();
                taxOutput.TaxableBase.TotalAmount = new DoubleTwoDecimalType((double)factura.Baseimp2);
                grossAmount += (double)factura.Baseimp2;
                taxOutput.TaxAmount = new AmountType();
                taxOutput.TaxAmount.TotalAmount = new DoubleTwoDecimalType((double)factura.Imporiv2);
                totalTaxOutputs += (double)factura.Imporiv2;
                inv.TaxesOutputs[1] = taxOutput;
            }
            catch (InvalidOperationException ioe)
            {
            }
            try
            {
                taxOutput = new TaxOutputType();
                taxOutput.TaxTypeCode = TaxTypeCodeType.Item01;
                taxOutput.TaxRate = new DoubleTwoDecimalType((double)factura.Porciva3);
                taxOutput.TaxableBase = new AmountType();
                taxOutput.TaxableBase.TotalAmount = new DoubleTwoDecimalType((double)factura.Baseimp3);
                grossAmount += (double)factura.Baseimp3;
                taxOutput.TaxAmount = new AmountType();
                taxOutput.TaxAmount.TotalAmount = new DoubleTwoDecimalType((double)factura.Imporiv3);
                totalTaxOutputs += (double)factura.Imporiv3;
                inv.TaxesOutputs[2] = taxOutput;
            }
            catch (InvalidOperationException ioe)
            {
            }
            
            #endregion
            
            inv.InvoiceTotals = new InvoiceTotalsType();
            //-- Discounts for this invoice
            
            #region[Discounts]
                
            double totalGeneralDiscounts = 0.0;

            if (factura.Dtognral != (decimal)0.0)
            {
                inv.InvoiceTotals.GeneralDiscounts = new DiscountType[2];
                DiscountType discountType;
                
                discountType = new DiscountType();
                discountType.DiscountRate = new DoubleFourDecimalType((double)factura.Dtognral);
                discountType.DiscountAmount = new DoubleSixDecimalType((double)(factura.Impdtogr));
                discountType.DiscountReason = "Descuento general.";
                discountType.DiscountRateSpecified = true;
                inv.InvoiceTotals.GeneralDiscounts[0] = discountType;
                totalGeneralDiscounts += discountType.DiscountAmount;
                    
                if (factura.Dtoppago != (decimal)0.0)
                {
                    discountType = new DiscountType();
                    discountType.DiscountRate = new DoubleFourDecimalType((double)factura.Dtoppago);
                    discountType.DiscountAmount = new DoubleSixDecimalType((double)(factura.Impdtopp));
                    discountType.DiscountReason = "Descuento pronto pago.";
                    discountType.DiscountRateSpecified = true;
                    inv.InvoiceTotals.GeneralDiscounts[1] = discountType;
                    totalGeneralDiscounts += discountType.DiscountAmount;
                }
            }
            
            #endregion
            
            ContaContext ctx2;

            //-- Totals for this invoice
            inv.InvoiceTotals.TotalGrossAmount = new DoubleTwoDecimalType((double)factura.Brutofac);
            inv.InvoiceTotals.TotalGeneralDiscounts = new DoubleTwoDecimalType(totalGeneralDiscounts);
            inv.InvoiceTotals.TotalGeneralDiscountsSpecified = true;
            inv.InvoiceTotals.TotalGeneralSurcharges = new DoubleTwoDecimalType(0.0);
            
            inv.InvoiceTotals.TotalGrossAmountBeforeTaxes = new DoubleTwoDecimalType((double)factura.Brutofac - totalGeneralDiscounts) + inv.InvoiceTotals.TotalGeneralSurcharges;
            inv.InvoiceTotals.TotalTaxOutputs = new DoubleTwoDecimalType(totalTaxOutputs);
            inv.InvoiceTotals.TotalTaxesWithheld = new DoubleTwoDecimalType(0);
            
            inv.InvoiceTotals.InvoiceTotal = new DoubleTwoDecimalType((double)factura.Totalfac);
            inv.InvoiceTotals.TotalOutstandingAmount = new DoubleTwoDecimalType((double)factura.Totalfac);
            inv.InvoiceTotals.TotalExecutableAmount = new DoubleTwoDecimalType((double)factura.Totalfac);
            
            //-- Invoice lines
            SparamTaxi param1 = ctx0.SparamTaxis.FirstOrDefault<SparamTaxi>();
            ctx2 = new ContaContext("contaEntity");
                                             
            i = 0;
            // hay que obtener las líneas de la factura, no se puede directamente desde OpenAccess
            // porque las referenciales son malas
            IList<Slifaccli> lineas = (from l in ctx0.Slifacclis
                                       where l.Codtipom == factura.Codtipom &&
                                             l.Numfactu == factura.Numfactu &&
                                             l.Fecfactu == factura.Fecfactu
                                       select l).ToList<Slifaccli>();
            inv.Items = new InvoiceLineType[lineas.Count]; // dimension = number of lines
            foreach (Slifaccli ln in lineas)
            {
                inv.Items[i] = InvoiceLine(ln, ctx2, ctx0);
                i++;
            }
            fcte.Invoices[0] = inv;

            #region [Payments]

            // Obtener la fecha de pago
            if (numCuenta != "")
            {
                if (factura.Svencicli != null)
                {
                    inv.PaymentDetails = new InstallmentType[1];
                    DateTime fechaPago = factura.Svencicli.Fecefect;
                    InstallmentType paymentDetail = new InstallmentType();
                    paymentDetail.InstallmentDueDate = fechaPago;
                    paymentDetail.InstallmentAmount = new DoubleTwoDecimalType((double)factura.Svencicli.Impefect);
                    // Se asume en todos los casos que el pago se hace por cuenta bancaria
                    paymentDetail.PaymentMeans = PaymentMeansType.Item04;
                    paymentDetail.AccountToBeCredited = new AccountType();
                    paymentDetail.AccountToBeCredited.ItemElementName = ItemChoiceType.IBAN;
                    paymentDetail.AccountToBeCredited.Item = numCuenta;
                    inv.PaymentDetails[0] = paymentDetail;
                }
            }
            
            #endregion
        }
        
        // son lineas para AriTaxi
        private InvoiceLineType InvoiceLine(Slifaccli line, ContaContext ctx2, AriTaxiContext ctx0)
        {
            // hay que obtener el código de IVA del artículo
            AriTaxiModel.Sartic articulo = (from a in ctx0.Sartics
                                            where a.Codartic == line.Codartic
                                            select a).FirstOrDefault<AriTaxiModel.Sartic>();
            byte codigIva = articulo.Codigiva;
            decimal porcentIva = obtenerPorcentajeIva(ctx2, codigIva);
            SparamTaxi param1 = ctx0.SparamTaxis.FirstOrDefault<SparamTaxi>();
            
            InvoiceLineType il = new InvoiceLineType();
            il.FileReference = line.NroExpediente;
            il.ItemDescription = line.Nomartic;
            if (line.Ampliaci != null)
                il.ItemDescription = il.ItemDescription + " " + line.Ampliaci;
            //il.Quantity = (double)line.Cantidad;
            il.Quantity = 1; // en AriTaxi es siempre 1
            il.UnitOfMeasure = UnitOfMeasureType.Item01; // TODO: Change for de correct unit type.
            double grossAmount = (double)line.Importel * (1.0 + ((double)porcentIva / 100.0));
            double unitPrice = (double)line.Precioar;
            //--
            //grossAmount = unitPrice * (double)line.Cantidad;
            double taxAmount = grossAmount - (double)line.Importel;
            il.UnitPriceWithoutTax = new DoubleSixDecimalType(unitPrice);
            unitPrice = Double.Parse(String.Format("{0:0.000000}", unitPrice));
            //grossAmount = unitPrice * (double)line.Cantidad;
            grossAmount = unitPrice * 1; // en AriTaxi la cantidad siempre es uno
            il.TotalCost = new DoubleSixDecimalType(grossAmount);
            
            double totalLineDiscounts = 0.0;
            DiscountType discountType;
            
            if (line.Dtoline1 != (decimal)0.0)
            {
                il.DiscountsAndRebates = new DiscountType[2];
                
                discountType = new DiscountType();
                discountType.DiscountRate = new DoubleFourDecimalType((double)line.Dtoline1);
                //discountType.DiscountAmount = new DoubleSixDecimalType((double)line.Cantidad * (double)line.Precioar * ((double)line.Dtoline1 / 100));
                discountType.DiscountAmount = new DoubleSixDecimalType((double)line.Precioar * ((double)line.Dtoline1 / 100)); // En AriTaxi la cantidad es uno
                discountType.DiscountReason = "Descuento 1.";
                discountType.DiscountRateSpecified = true;
                il.DiscountsAndRebates[0] = discountType;
                totalLineDiscounts += discountType.DiscountAmount;
                // alparecer no se usan descuentos en AriTaxi
                //if (line.Dtoline2 != (decimal)0.0)
                //{
                //    discountType = new DiscountType();
                //    discountType.DiscountRate = new DoubleFourDecimalType((double)line.Dtoline2);
                //    if (param1.Ordendto == 0)
                //        discountType.DiscountAmount = new DoubleSixDecimalType((double)line.Cantidad * (double)line.Precioar * ((double)line.Dtoline2 / 100));
                //    else
                //        discountType.DiscountAmount = new DoubleSixDecimalType(((double)line.Cantidad * (double)line.Precioar - il.DiscountsAndRebates[0].DiscountAmount) * ((double)line.Dtoline2 / 100));
                //    discountType.DiscountReason = "Descuento 2.";
                //    discountType.DiscountRateSpecified = true;
                //    il.DiscountsAndRebates[1] = discountType;
                //    totalLineDiscounts += discountType.DiscountAmount;
                //}
            }
            il.GrossAmount = new DoubleSixDecimalType(grossAmount - totalLineDiscounts);
            il.TaxesOutputs = new InvoiceLineTypeTax[1]; // only one tax per line
            InvoiceLineTypeTax lTax = new InvoiceLineTypeTax();
            lTax.TaxTypeCode = TaxTypeCodeType.Item01; // always VAT
            lTax.TaxRate = new DoubleTwoDecimalType((double)porcentIva);
            lTax.TaxableBase = new AmountType();
            lTax.TaxableBase.TotalAmount = new DoubleTwoDecimalType(grossAmount);
            lTax.TaxAmount = new AmountType();
            lTax.TaxAmount.TotalAmount = new DoubleTwoDecimalType(taxAmount);
            il.TaxesOutputs[0] = lTax;
            return il;
        }
        
        public static string getCodtipom(string numSerie, AriTaxiContext ctx0)
        {
            string codTipom = (from s in ctx0.StipomTaxis
                               where s.Letraser == numSerie
                               select s).First<StipomTaxi>().Codtipom;
            return codTipom;
        }
        
        private string getLetraSerie(string codtipom, AriTaxiContext ctx0)
        {
            return (from c in ctx0.StipomTaxis
                    where c.Codtipom == codtipom
                    select c).FirstOrDefault<StipomTaxi>().Letraser;
        }
        
        #endregion
        
        #region ARIGES FACTURAE
        
        public static string getCodtipom(string numSerie, ArigesContext ctx0)
        {
            string codTipom = (from s in ctx0.Stipoms
                               where s.Letraser == numSerie
                               select s).First<Stipom>().Codtipom;
            return codTipom;
        }
        
        private string getLetraSerie(string codtipom, ArigesContext ctx0)
        {
            return (from c in ctx0.Stipoms
                    where c.Codtipom == codtipom
                    select c).FirstOrDefault<Stipom>().Letraser;
        }
        
        private void FileHeaderGdes(Facturae fcte, Cau_FIN_FACEInvoiceHeader gdesHeader)
        {
            // File Header.
            fcte.FileHeader = new FileHeaderType();
            fcte.FileHeader.SchemaVersion = SchemaVersionType.Item32; // 3.1 Version
            fcte.FileHeader.Modality = ModalityType.I; // Individual
            fcte.FileHeader.InvoiceIssuerType = InvoiceIssuerTypeType.EM; // Issuer is "EMISOR"
            
            // Constructing batch identifier = Issuer nif + invoice serial + invoice number + invoice date
            string batchIdentifier = String.Format("{0}{1:0000000}{2:yyyMMdd}",
                gdesHeader.SellerTaxIdentificationNumber,
                gdesHeader.InvoiceNumber,
                gdesHeader.IssueDate);
            fcte.FileHeader.Batch = new BatchType();
            fcte.FileHeader.Batch.BatchIdentifier = batchIdentifier;
            fcte.FileHeader.Batch.InvoicesCount = 1; // Modality is individual 1 invoice per file
            
            // all amounts have the same value
            fcte.FileHeader.Batch.TotalInvoicesAmount = new AmountType();
            fcte.FileHeader.Batch.TotalInvoicesAmount.TotalAmount = new DoubleTwoDecimalType((double)gdesHeader.InvoiceTotals);
            fcte.FileHeader.Batch.TotalOutstandingAmount = new AmountType();
            fcte.FileHeader.Batch.TotalOutstandingAmount.TotalAmount = new DoubleTwoDecimalType((double)gdesHeader.InvoiceTotals);
            fcte.FileHeader.Batch.TotalExecutableAmount = new AmountType();
            fcte.FileHeader.Batch.TotalExecutableAmount.TotalAmount = new DoubleTwoDecimalType((double)gdesHeader.InvoiceTotals);
            fcte.FileHeader.Batch.InvoiceCurrencyCode = CurrencyCodeType.EUR; // invoices is in euros
        }
        
        private void FileHeaderAriGes(Facturae fcte, Scafac factura, ArigesContext ctx0)
        {
            // File Header.
            fcte.FileHeader = new FileHeaderType();
            fcte.FileHeader.SchemaVersion = SchemaVersionType.Item32; // 3.1 Version
            fcte.FileHeader.Modality = ModalityType.I; // Individual
            fcte.FileHeader.InvoiceIssuerType = InvoiceIssuerTypeType.EM; // Issuer is "EMISOR"
            
            // Constructing batch identifier = Issuer nif + invoice serial + invoice number + invoice date
            string letrafac = getLetraSerie(factura.Codtipom, ctx0);
            string batchIdentifier = String.Format("{0}{1}{2:0000000}{3:yyyMMdd}",
                factura.Nifclien,
                letrafac,
                factura.Numfactu,
                factura.Fecfactu);
            fcte.FileHeader.Batch = new BatchType();
            fcte.FileHeader.Batch.BatchIdentifier = batchIdentifier;
            fcte.FileHeader.Batch.InvoicesCount = 1; // Modality is individual 1 invoice per file
            
            // all amounts have the same value
            fcte.FileHeader.Batch.TotalInvoicesAmount = new AmountType();
            fcte.FileHeader.Batch.TotalInvoicesAmount.TotalAmount = new DoubleTwoDecimalType((double)factura.Totalfac);
            fcte.FileHeader.Batch.TotalOutstandingAmount = new AmountType();
            fcte.FileHeader.Batch.TotalOutstandingAmount.TotalAmount = new DoubleTwoDecimalType((double)factura.Totalfac);
            fcte.FileHeader.Batch.TotalExecutableAmount = new AmountType();
            fcte.FileHeader.Batch.TotalExecutableAmount.TotalAmount = new DoubleTwoDecimalType((double)factura.Totalfac);
            fcte.FileHeader.Batch.InvoiceCurrencyCode = CurrencyCodeType.EUR; // invoices is in euros
        }
        
        private void PartiesGdes(Facturae fcte, Cau_FIN_FACEInvoiceHeader gdesHeader)
        {
            // TODO: Person type code must be obtained from NIF
            fcte.Parties = new PartiesType();
            fcte.Parties.SellerParty = new BusinessType();
            fcte.Parties.SellerParty.TaxIdentification = new TaxIdentificationType();
            fcte.Parties.SellerParty.TaxIdentification.PersonTypeCode = PersonTypeCodeType.J;
            fcte.Parties.SellerParty.TaxIdentification.ResidenceTypeCode = ResidenceTypeCodeType.R;
            fcte.Parties.SellerParty.TaxIdentification.TaxIdentificationNumber = gdesHeader.SellerTaxIdentificationNumber;
            
            //Ciudade ciu = (from c in ctx1.Ciudades
            //               where c.Codposta == empresa.Codposta
            //               select c).FirstOrDefault<Ciudade>();
            LegalEntityType legalEntity = new LegalEntityType();
            legalEntity.CorporateName = gdesHeader.SellerCorporateName;
            AddressType address = new AddressType();
            address.Address = gdesHeader.SellerAddress;
            address.PostCode = gdesHeader.SellerPostCode;
            address.Town = gdesHeader.SellerTown;
            address.Province = gdesHeader.SellerProvince;
            address.CountryCode = CountryType.ESP;
            legalEntity.Item = address;
            
            fcte.Parties.SellerParty.Item = legalEntity;
            
            fcte.Parties.BuyerParty = new BusinessType();
            fcte.Parties.BuyerParty.TaxIdentification = new TaxIdentificationType();
            fcte.Parties.BuyerParty.TaxIdentification.PersonTypeCode = PersonTypeCodeType.J;
            fcte.Parties.BuyerParty.TaxIdentification.ResidenceTypeCode = ResidenceTypeCodeType.R;
            fcte.Parties.BuyerParty.TaxIdentification.TaxIdentificationNumber = gdesHeader.BuyerTaxIdentificationNumber;
            // comprobacion de las unidades FACE
            // Hay que controlar en el caso de clientes de administración pública
            // montar la información de oficina contable, organo gestor y unidad tramitadora.
            // buscamos el cliente en FActuraE para ver si contiene las columnas
            FacturaEntity ctx4 = new FacturaEntity("FacturaEntity");
            
            // En GDES los datos face vienen en la propia factura
            
            // Comprobamos que tiene los códigos para operar en Adm. Pública
            if (gdesHeader.CODIGOORGANOGESTOR != null && gdesHeader.CODIGOORGANOGESTOR != "")
            {
                // Ahora hay que leer la unidad para conocer sus códigos
                Unidad uAdm = (from u in ctx4.Unidads
                               where u.OficinaContableCodigo == gdesHeader.CODIGOOFICINACONTABLE &&
                                     u.OrganoGestorCodigo == gdesHeader.CODIGOORGANOGESTOR &&
                                     u.UnidadTramitadoraCodigo == gdesHeader.CODIGOUNIDADTRAMITADORA
                               select u).FirstOrDefault<Unidad>();
                
                // De momento montamos todas las direcciones como comunes
                address = new AddressType();
                address.Address = gdesHeader.BuyerAddress;
                address.PostCode = gdesHeader.BuyerPostCode;
                address.Town = gdesHeader.BuyerTown;
                address.Province = gdesHeader.BuyerProvince;
                address.CountryCode = CountryType.ESP;
                
                if (uAdm != null)
                {
                    // Ahora montamos las diferentes unidades administrativas (3)
                    fcte.Parties.BuyerParty.AdministrativeCentres = new AdministrativeCentreType[3];
                    AdministrativeCentreType admCenter = new AdministrativeCentreType();
                    // Organo gestor
                    admCenter.CentreCode = uAdm.OrganoGestorCodigo;
                    admCenter.RoleTypeCode = RoleTypeCodeType.Item02;
                    admCenter.RoleTypeCodeSpecified = true;
                    admCenter.Item = address;
                    admCenter.CentreDescription = uAdm.OrganoGestorNombre;
                    fcte.Parties.BuyerParty.AdministrativeCentres[0] = admCenter;
                    // Unidad tramitadora
                    admCenter = new AdministrativeCentreType();
                    admCenter.CentreCode = uAdm.UnidadTramitadoraCodigo;
                    admCenter.RoleTypeCode = RoleTypeCodeType.Item03;
                    admCenter.RoleTypeCodeSpecified = true;
                    admCenter.Item = address;
                    admCenter.CentreDescription = uAdm.UnidadTramitadoraNombre;
                    fcte.Parties.BuyerParty.AdministrativeCentres[1] = admCenter;
                    // oficina contable
                    admCenter = new AdministrativeCentreType();
                    admCenter.CentreCode = uAdm.OficinaContableCodigo;
                    admCenter.RoleTypeCode = RoleTypeCodeType.Item01;
                    admCenter.RoleTypeCodeSpecified = true;
                    admCenter.Item = address;
                    admCenter.CentreDescription = uAdm.OficinaContableNombre;
                    fcte.Parties.BuyerParty.AdministrativeCentres[2] = admCenter;
                }
                else
                {
                    // Ahora montamos las diferentes unidades administrativas (3)
                    fcte.Parties.BuyerParty.AdministrativeCentres = new AdministrativeCentreType[3];
                    AdministrativeCentreType admCenter = new AdministrativeCentreType();
                    // Organo gestor
                    admCenter.CentreCode = gdesHeader.CODIGOORGANOGESTOR;
                    admCenter.RoleTypeCode = RoleTypeCodeType.Item02;
                    admCenter.RoleTypeCodeSpecified = true;
                    admCenter.Item = address;
                    admCenter.CentreDescription = gdesHeader.BuyerCorporateName;
                    fcte.Parties.BuyerParty.AdministrativeCentres[0] = admCenter;
                    // Unidad tramitadora
                    admCenter = new AdministrativeCentreType();
                    admCenter.CentreCode = gdesHeader.CODIGOUNIDADTRAMITADORA;
                    admCenter.RoleTypeCode = RoleTypeCodeType.Item03;
                    admCenter.RoleTypeCodeSpecified = true;
                    admCenter.Item = address;
                    admCenter.CentreDescription = gdesHeader.BuyerCorporateName;
                    fcte.Parties.BuyerParty.AdministrativeCentres[1] = admCenter;
                    // oficina contable
                    admCenter = new AdministrativeCentreType();
                    admCenter.CentreCode = gdesHeader.CODIGOOFICINACONTABLE;
                    admCenter.RoleTypeCode = RoleTypeCodeType.Item01;
                    admCenter.RoleTypeCodeSpecified = true;
                    admCenter.Item = address;
                    admCenter.CentreDescription = gdesHeader.BuyerCorporateName;
                    fcte.Parties.BuyerParty.AdministrativeCentres[2] = admCenter;
                }
            }
            
            //ciu = (from c in ctx1.Ciudades
            //       where c.Codposta == cliente.Codposfs
            //       select c).FirstOrDefault<Ciudade>();
            legalEntity = new LegalEntityType();
            legalEntity.CorporateName = gdesHeader.BuyerCorporateName;
            address = new AddressType();
            address.Address = gdesHeader.BuyerAddress;
            address.PostCode = gdesHeader.BuyerPostCode;
            address.Town = gdesHeader.BuyerTown;
            address.Province = gdesHeader.BuyerProvince;
            address.CountryCode = CountryType.ESP;
            legalEntity.Item = address;
            fcte.Parties.BuyerParty.Item = legalEntity;
        }
        
        private void PartiesAriGes(Facturae fcte, Sparam empresa, Scafac factura, Empresa emp2, ArigesContext ctx0)
        {
            // TODO: Person type code must be obtained from NIF
            fcte.Parties = new PartiesType();
            fcte.Parties.SellerParty = new BusinessType();
            fcte.Parties.SellerParty.TaxIdentification = new TaxIdentificationType();
            fcte.Parties.SellerParty.TaxIdentification.PersonTypeCode = PersonTypeCodeType.J;
            fcte.Parties.SellerParty.TaxIdentification.ResidenceTypeCode = ResidenceTypeCodeType.R;
            fcte.Parties.SellerParty.TaxIdentification.TaxIdentificationNumber = empresa.Cifempre;
            
            //Ciudade ciu = (from c in ctx1.Ciudades
            //               where c.Codposta == empresa.Codposta
            //               select c).FirstOrDefault<Ciudade>();
            LegalEntityType legalEntity = new LegalEntityType();
            legalEntity.CorporateName = empresa.Nomempre;
            AddressType address = new AddressType();
            address.Address = empresa.Domempre;
            address.PostCode = empresa.Codpobla;
            address.Town = empresa.Pobempre;
            address.Province = empresa.Proempre;
            address.CountryCode = CountryType.ESP;
            legalEntity.Item = address;
            if (emp2 != null)
            {
                RegistrationDataType registro = new RegistrationDataType();
                registro.AdditionalRegistrationData = emp2.Regcomentarios;
                registro.Book = emp2.Libro;
                registro.Folio = emp2.Folio;
                registro.RegisterOfCompaniesLocation = emp2.Registro;
                registro.Section = emp2.Seccion;
                registro.Sheet = emp2.Hoja;
                registro.Volume = emp2.Tomo;
                legalEntity.RegistrationData = registro;
            }
            
            fcte.Parties.SellerParty.Item = legalEntity;
            
            AriFacElec.Sclien cliente = (from c in ctx0.Scliens
                                         where c.Codclien == factura.Codclien
                                         select c).FirstOrDefault<AriFacElec.Sclien>();
            fcte.Parties.BuyerParty = new BusinessType();
            fcte.Parties.BuyerParty.TaxIdentification = new TaxIdentificationType();
            fcte.Parties.BuyerParty.TaxIdentification.PersonTypeCode = PersonTypeCodeType.J;
            fcte.Parties.BuyerParty.TaxIdentification.ResidenceTypeCode = ResidenceTypeCodeType.R;
            fcte.Parties.BuyerParty.TaxIdentification.TaxIdentificationNumber = cliente.Nifclien;
            // comprobacion de las unidades FACE
            // Hay que controlar en el caso de clientes de administración pública
            // montar la información de oficina contable, organo gestor y unidad tramitadora.
            // buscamos el cliente en FActuraE para ver si contiene las columnas
            FacturaEntity ctx4 = new FacturaEntity("FacturaEntity");
            Cliente cFacturae = (from c in ctx4.Clientes
                                 where c.CodclienAriges == cliente.Codclien
                                 select c).FirstOrDefault<Cliente>();
            if (cFacturae != null)
            {
                // Comprobamos que tiene los códigos para operar en Adm. Pública
                if (cFacturae.OrganoGestorCodigo != null && cFacturae.OrganoGestorCodigo != "")
                {
                    // Ahora hay que leer la unidad para conocer sus códigos
                    Unidad uAdm = (from u in ctx4.Unidads
                                   where u.OficinaContableCodigo == cFacturae.OficinaContableCodigo &&
                                         u.OrganoGestorCodigo == cFacturae.OrganoGestorCodigo &&
                                         u.UnidadTramitadoraCodigo == cFacturae.UnidadTramitadoraCodigo
                                   select u).FirstOrDefault<Unidad>();
                    
                    // De momento montamos todas las direcciones como comunes
                    address = new AddressType();
                    address.Address = cliente.Domclien;
                    address.PostCode = cliente.Codpobla;
                    address.Town = cliente.Pobclien;
                    address.Province = cliente.Proclien;
                    address.CountryCode = CountryType.ESP;
                    
                    if (uAdm != null)
                    {
                        // Ahora montamos las diferentes unidades administrativas (3)
                        fcte.Parties.BuyerParty.AdministrativeCentres = new AdministrativeCentreType[3];
                        AdministrativeCentreType admCenter = new AdministrativeCentreType();
                        // Organo gestor
                        admCenter.CentreCode = cFacturae.OrganoGestorCodigo;
                        admCenter.RoleTypeCode = RoleTypeCodeType.Item02;
                        admCenter.RoleTypeCodeSpecified = true;
                        admCenter.Item = address;
                        admCenter.CentreDescription = cliente.Nomclien;
                        fcte.Parties.BuyerParty.AdministrativeCentres[0] = admCenter;
                        // Unidad tramitadora
                        admCenter = new AdministrativeCentreType();
                        admCenter.CentreCode = cFacturae.UnidadTramitadoraCodigo;
                        admCenter.RoleTypeCode = RoleTypeCodeType.Item03;
                        admCenter.RoleTypeCodeSpecified = true;
                        admCenter.Item = address;
                        admCenter.CentreDescription = cliente.Nomclien;
                        fcte.Parties.BuyerParty.AdministrativeCentres[1] = admCenter;
                        // oficina contable
                        admCenter = new AdministrativeCentreType();
                        admCenter.CentreCode = cFacturae.OficinaContableCodigo;
                        admCenter.RoleTypeCode = RoleTypeCodeType.Item01;
                        admCenter.RoleTypeCodeSpecified = true;
                        admCenter.Item = address;
                        admCenter.CentreDescription = cliente.Nomclien;
                        fcte.Parties.BuyerParty.AdministrativeCentres[2] = admCenter;
                    }
                    else
                    {
                        // Ahora montamos las diferentes unidades administrativas (3)
                        fcte.Parties.BuyerParty.AdministrativeCentres = new AdministrativeCentreType[3];
                        AdministrativeCentreType admCenter = new AdministrativeCentreType();
                        // Organo gestor
                        admCenter.CentreCode = uAdm.OrganoGestorCodigo;
                        admCenter.RoleTypeCode = RoleTypeCodeType.Item02;
                        admCenter.RoleTypeCodeSpecified = true;
                        admCenter.Item = address;
                        admCenter.CentreDescription = uAdm.OrganoGestorNombre;
                        fcte.Parties.BuyerParty.AdministrativeCentres[0] = admCenter;
                        // Unidad tramitadora
                        admCenter = new AdministrativeCentreType();
                        admCenter.CentreCode = uAdm.UnidadTramitadoraCodigo;
                        admCenter.RoleTypeCode = RoleTypeCodeType.Item03;
                        admCenter.RoleTypeCodeSpecified = true;
                        admCenter.Item = address;
                        admCenter.CentreDescription = uAdm.UnidadTramitadoraNombre;
                        fcte.Parties.BuyerParty.AdministrativeCentres[1] = admCenter;
                        // oficina contable
                        admCenter = new AdministrativeCentreType();
                        admCenter.CentreCode = uAdm.OficinaContableCodigo;
                        admCenter.RoleTypeCode = RoleTypeCodeType.Item01;
                        admCenter.RoleTypeCodeSpecified = true;
                        admCenter.Item = address;
                        admCenter.CentreDescription = uAdm.OficinaContableNombre;
                        fcte.Parties.BuyerParty.AdministrativeCentres[2] = admCenter;
                    }
                }
            }
            //ciu = (from c in ctx1.Ciudades
            //       where c.Codposta == cliente.Codposfs
            //       select c).FirstOrDefault<Ciudade>();
            legalEntity = new LegalEntityType();
            legalEntity.CorporateName = cliente.Nomcomer;
            address = new AddressType();
            address.Address = cliente.Domclien;
            address.PostCode = cliente.Codpobla;
            address.Town = cliente.Pobclien;
            address.Province = cliente.Proclien;
            address.CountryCode = CountryType.ESP;
            legalEntity.Item = address;
            fcte.Parties.BuyerParty.Item = legalEntity;
        }
        
        private void InvoicesGdes(Facturae fcte, Cau_FIN_FACEInvoiceHeader gdesHeader, GdesModelo ctx5)
        {
            fcte.Invoices = new InvoiceType[1]; // One invoice only
            InvoiceType inv = new InvoiceType();
            inv.InvoiceHeader = new InvoiceHeaderType();
            inv.InvoiceHeader.InvoiceNumber = gdesHeader.InvoiceNumber;
            inv.InvoiceHeader.InvoiceSeriesCode = ""; // Ask for some more iformation
            inv.InvoiceHeader.InvoiceClass = InvoiceClassType.OO; // TODO: We are fixing invoice class value (perhaps incorrect)
            
            inv.InvoiceIssueData = new InvoiceIssueDataType();
            inv.InvoiceIssueData.IssueDate = gdesHeader.IssueDate;
            DateTime fechaNula = new DateTime(1900, 1, 1);
            if (gdesHeader.PeriodoFactDesde != fechaNula && gdesHeader.PeriodoFactHasta != fechaNula)
            {
                PeriodDates pd = new PeriodDates();
                pd.StartDate = gdesHeader.PeriodoFactDesde;
                pd.EndDate = gdesHeader.PeriodoFactHasta;
                //inv.InvoiceIssueData.InvoicingPeriod.StartDate = gdesHeader.PeriodoFactDesde;
                //inv.InvoiceIssueData.InvoicingPeriod.EndDate = gdesHeader.PeriodoFactHasta;
                inv.InvoiceIssueData.InvoicingPeriod = pd;
            }
            inv.InvoiceIssueData.InvoiceCurrencyCode = CurrencyCodeType.EUR; // fixed euros
            inv.InvoiceIssueData.TaxCurrencyCode = CurrencyCodeType.EUR; // taxes in euros too.
            inv.InvoiceIssueData.LanguageName = LanguageCodeType.es; // always in Spanish
            
            int i = 0; // index of TaxesOutputs (begins cero)
            double grossAmount = 0;
            double totalTaxOutputs = 0;
            TaxOutputType taxOutput; // each tax output
            // AriGes invoice could have 3 diferent fixed taxes
            
            #region[IVA]
            
            IList<Cau_FIN_FACEInvoiceTax> taxes = (from t in ctx5.Cau_FIN_FACEInvoiceTaxes
                                                   where t.ID == gdesHeader.ID
                                                   select t).ToList<Cau_FIN_FACEInvoiceTax>();
            inv.TaxesOutputs = new TaxOutputType[taxes.Count];
            int index = 0;
            foreach (Cau_FIN_FACEInvoiceTax tx in taxes)
            {
                try
                {
                    taxOutput = new TaxOutputType();
                    taxOutput.TaxTypeCode = TaxTypeCodeType.Item01;
                    taxOutput.TaxRate = new DoubleTwoDecimalType((double)tx.TaxRate);
                    taxOutput.TaxableBase = new AmountType();
                    taxOutput.TaxableBase.TotalAmount = new DoubleTwoDecimalType((double)tx.TAXBASEAMOUNT);
                    grossAmount += (double)tx.TAXBASEAMOUNT;
                    taxOutput.TaxAmount = new AmountType();
                    taxOutput.TaxAmount.TotalAmount = new DoubleTwoDecimalType((double)tx.TAXAMOUNT);
                    totalTaxOutputs += (double)tx.TAXAMOUNT;
                    inv.TaxesOutputs[index] = taxOutput;
                }
                catch (InvalidOperationException ioe)
                {
                }
                index++;
            }
            
            #endregion
            
            inv.InvoiceTotals = new InvoiceTotalsType();
            //-- Discounts for this invoice
            
            #region[Discounts]
            
            double totalGeneralDiscounts = 0.0;
            
            #endregion
            
            ContaContext ctx2;
            
            //-- Totals for this invoice
            inv.InvoiceTotals.TotalGrossAmount = new DoubleTwoDecimalType((double)gdesHeader.TotalGrossAmount);
            inv.InvoiceTotals.TotalGeneralDiscounts = new DoubleTwoDecimalType(totalGeneralDiscounts);
            inv.InvoiceTotals.TotalGeneralDiscountsSpecified = true;
            inv.InvoiceTotals.TotalGeneralSurcharges = new DoubleTwoDecimalType(0.0);
            
            inv.InvoiceTotals.TotalGrossAmountBeforeTaxes = new DoubleTwoDecimalType((double)gdesHeader.TotalGrossAmount - totalGeneralDiscounts) + inv.InvoiceTotals.TotalGeneralSurcharges;
            inv.InvoiceTotals.TotalTaxOutputs = new DoubleTwoDecimalType(totalTaxOutputs);
            inv.InvoiceTotals.TotalTaxesWithheld = new DoubleTwoDecimalType(0);
            
            inv.InvoiceTotals.InvoiceTotal = new DoubleTwoDecimalType((double)gdesHeader.InvoiceTotals);
            inv.InvoiceTotals.TotalOutstandingAmount = new DoubleTwoDecimalType((double)gdesHeader.TotalOutstandingAmount);
            inv.InvoiceTotals.TotalExecutableAmount = new DoubleTwoDecimalType((double)gdesHeader.TotalExecutableAmount);
            
            // Read invoice lines in order to process them
            IList<Cau_FIN_FACEInvoiceLine> lines = (from l in ctx5.Cau_FIN_FACEInvoiceLines
                                                    where l.ID == gdesHeader.ID
                                                    select l).ToList<Cau_FIN_FACEInvoiceLine>();
            
            i = 0;
            inv.Items = new InvoiceLineType[lines.Count]; // dimension = number of lines
            foreach (Cau_FIN_FACEInvoiceLine ln in lines)
            {
                inv.Items[i] = InvoiceLineGdes(ln);
                i++;
            }
            
            #region [Payments]
            
            inv.PaymentDetails = new InstallmentType[1];
            InstallmentType paymentDetail = new InstallmentType();
            paymentDetail.InstallmentDueDate = gdesHeader.InstallmentDueDate;
            paymentDetail.InstallmentAmount = new DoubleTwoDecimalType((double)gdesHeader.InstallmentAmount);
            
            paymentDetail.PaymentMeans = PaymentMeansType.Item04;
            paymentDetail.AccountToBeCredited = new AccountType();
            paymentDetail.AccountToBeCredited.ItemElementName = ItemChoiceType.IBAN;
            paymentDetail.AccountToBeCredited.Item = gdesHeader.IBAN;
            inv.PaymentDetails[0] = paymentDetail;
            
            #endregion
            
            fcte.Invoices[0] = inv;
        }
        
        private InvoiceLineType InvoiceLineGdes(Cau_FIN_FACEInvoiceLine line)
        {
            InvoiceLineType il = new InvoiceLineType();
            il.ItemDescription = line.ItemDescription;
            il.Quantity = (double)line.Quantity;
            il.UnitOfMeasure = UnitOfMeasureType.Item01; // TODO: Change for de correct unit type.
            double grossAmount = (double)line.GrossAmount + (double)line.TaxAmount;
            double unitPrice = (double)line.GrossAmount / (double)line.Quantity;
            //--
            //grossAmount = unitPrice * (double)line.Cantidad;
            double taxAmount = (double)line.TaxAmount;
            il.UnitPriceWithoutTax = new DoubleSixDecimalType(unitPrice);
            unitPrice = Double.Parse(String.Format("{0:0.000000}", unitPrice));
            grossAmount = (double)line.GrossAmount; 
            il.TotalCost = new DoubleSixDecimalType(grossAmount);
            
            double totalLineDiscounts = 0.0;
            DiscountType discountType;
            
            il.GrossAmount = new DoubleSixDecimalType(grossAmount - totalLineDiscounts);
            il.TaxesOutputs = new InvoiceLineTypeTax[1]; // only one tax per line
            InvoiceLineTypeTax lTax = new InvoiceLineTypeTax();
            lTax.TaxTypeCode = TaxTypeCodeType.Item01; // always VAT
            lTax.TaxRate = new DoubleTwoDecimalType((double)line.TaxRate);
            lTax.TaxableBase = new AmountType();
            lTax.TaxableBase.TotalAmount = new DoubleTwoDecimalType(grossAmount);
            lTax.TaxAmount = new AmountType();
            lTax.TaxAmount.TotalAmount = new DoubleTwoDecimalType(taxAmount);
            il.TaxesOutputs[0] = lTax;
            return il;
        }
        
        // -- TEINSA -- Control de descuentos
        private InvoiceLineType InvoiceLine(Slifac line, ContaContext ctx2, ArigesContext ctx0)
        {
            byte codigIva = line.Sartic.Codigiva;
            decimal porcentIva = obtenerPorcentajeIva(ctx2, codigIva);
            Spara1 param1 = ctx0.Spara1.FirstOrDefault<Spara1>();
            InvoiceLineType il = new InvoiceLineType();
            il.ItemDescription = line.Nomartic;
            if (line.Ampliaci != null)
                il.ItemDescription = il.ItemDescription + " " + line.Ampliaci;
            il.Quantity = (double)line.Cantidad;
            il.UnitOfMeasure = UnitOfMeasureType.Item01; // TODO: Change for de correct unit type.
            double grossAmount = (double)line.Importel * (1.0 + ((double)porcentIva / 100.0));
            double unitPrice = (double)line.Precioar;
            //--
            //grossAmount = unitPrice * (double)line.Cantidad;
            double taxAmount = grossAmount - (double)line.Importel;
            il.UnitPriceWithoutTax = new DoubleSixDecimalType(unitPrice);
            unitPrice = Double.Parse(String.Format("{0:0.000000}", unitPrice));
            grossAmount = unitPrice * (double)line.Cantidad;
            il.TotalCost = new DoubleSixDecimalType(il.Quantity * unitPrice);
            
            double totalLineDiscounts = 0.0;
            DiscountType discountType;
            
            if (line.Dtoline1 != (decimal)0.0)
            {
                il.DiscountsAndRebates = new DiscountType[2];
                
                discountType = new DiscountType();
                discountType.DiscountRate = new DoubleFourDecimalType((double)line.Dtoline1);
                discountType.DiscountAmount = new DoubleSixDecimalType(Math.Round((double)line.Cantidad * (double)line.Precioar * ((double)line.Dtoline1 / 100), 2));
                discountType.DiscountReason = "Descuento 1.";
                discountType.DiscountRateSpecified = true;
                il.DiscountsAndRebates[0] = discountType;
                totalLineDiscounts += discountType.DiscountAmount;
                
                if (line.Dtoline2 != (decimal)0.0)
                {
                    discountType = new DiscountType();
                    discountType.DiscountRate = new DoubleFourDecimalType((double)line.Dtoline2);
                    if (param1.Tipodtos == 0)
                        discountType.DiscountAmount = new DoubleSixDecimalType(Math.Round((double)line.Cantidad * (double)line.Precioar * ((double)line.Dtoline2 / 100), 2));
                    else
                        discountType.DiscountAmount = new DoubleSixDecimalType(Math.Round(((double)line.Cantidad * (double)line.Precioar - il.DiscountsAndRebates[0].DiscountAmount) * ((double)line.Dtoline2 / 100), 2));
                    discountType.DiscountReason = "Descuento 2.";
                    discountType.DiscountRateSpecified = true;
                    il.DiscountsAndRebates[1] = discountType;
                    totalLineDiscounts += discountType.DiscountAmount;
                }
            }
            
            //il.GrossAmount = new DoubleSixDecimalType(grossAmount - totalLineDiscounts);
            il.GrossAmount = new DoubleSixDecimalType((double)line.Importel);
            //il.TotalCost = il.GrossAmount;
            il.TaxesOutputs = new InvoiceLineTypeTax[1]; // only one tax per line
            InvoiceLineTypeTax lTax = new InvoiceLineTypeTax();
            lTax.TaxTypeCode = TaxTypeCodeType.Item01; // always VAT
            lTax.TaxRate = new DoubleTwoDecimalType((double)porcentIva);
            lTax.TaxableBase = new AmountType();
            //lTax.TaxableBase.TotalAmount = new DoubleTwoDecimalType(grossAmount);
            lTax.TaxableBase.TotalAmount = new DoubleTwoDecimalType((double)line.Importel - taxAmount);
            lTax.TaxAmount = new AmountType();
            lTax.TaxAmount.TotalAmount = new DoubleTwoDecimalType(taxAmount);
            il.TaxesOutputs[0] = lTax;
            return il;
        }
        
        private void InvoicesAriGes(Facturae fcte, Scafac factura, string numCuenta, ArigesContext ctx0)
        {
            fcte.Invoices = new InvoiceType[1]; // One invoice only
            InvoiceType inv = new InvoiceType();
            inv.InvoiceHeader = new InvoiceHeaderType();
            inv.InvoiceHeader.InvoiceNumber = factura.Numfactu.ToString();
            inv.InvoiceHeader.InvoiceSeriesCode = getLetraSerie(factura.Codtipom, ctx0).ToString();
            inv.InvoiceHeader.InvoiceClass = InvoiceClassType.OO; // TODO: We are fixing invoice class value (perhaps incorrect)
            
            inv.InvoiceIssueData = new InvoiceIssueDataType();
            inv.InvoiceIssueData.IssueDate = factura.Fecfactu;
            inv.InvoiceIssueData.InvoiceCurrencyCode = CurrencyCodeType.EUR; // fixed euros
            inv.InvoiceIssueData.TaxCurrencyCode = CurrencyCodeType.EUR; // taxes in euros too.
            inv.InvoiceIssueData.LanguageName = LanguageCodeType.es; // always in Spanish
            
            inv.TaxesOutputs = new TaxOutputType[3];
            int i = 0; // index of TaxesOutputs (begins cero)
            double grossAmount = 0;
            double totalTaxOutputs = 0;
            TaxOutputType taxOutput; // each tax output
            // AriGes invoice could have 3 diferent fixed taxes
            
            #region[IVA]
            
            try
            {
                taxOutput = new TaxOutputType();
                taxOutput.TaxTypeCode = TaxTypeCodeType.Item01;
                taxOutput.TaxRate = new DoubleTwoDecimalType((double)factura.Porciva1);
                taxOutput.TaxableBase = new AmountType();
                taxOutput.TaxableBase.TotalAmount = new DoubleTwoDecimalType((double)factura.Baseimp1);
                grossAmount += (double)factura.Baseimp1;
                taxOutput.TaxAmount = new AmountType();
                taxOutput.TaxAmount.TotalAmount = new DoubleTwoDecimalType((double)factura.Imporiv1);
                totalTaxOutputs += (double)factura.Imporiv1;
                inv.TaxesOutputs[0] = taxOutput;
            }
            catch (InvalidOperationException ioe)
            {
            }
            try
            {
                taxOutput = new TaxOutputType();
                taxOutput.TaxTypeCode = TaxTypeCodeType.Item01;
                taxOutput.TaxRate = new DoubleTwoDecimalType((double)factura.Porciva2);
                taxOutput.TaxableBase = new AmountType();
                taxOutput.TaxableBase.TotalAmount = new DoubleTwoDecimalType((double)factura.Baseimp2);
                grossAmount += (double)factura.Baseimp2;
                taxOutput.TaxAmount = new AmountType();
                taxOutput.TaxAmount.TotalAmount = new DoubleTwoDecimalType((double)factura.Imporiv2);
                totalTaxOutputs += (double)factura.Imporiv2;
                inv.TaxesOutputs[1] = taxOutput;
            }
            catch (InvalidOperationException ioe)
            {
            }
            try
            {
                taxOutput = new TaxOutputType();
                taxOutput.TaxTypeCode = TaxTypeCodeType.Item01;
                taxOutput.TaxRate = new DoubleTwoDecimalType((double)factura.Porciva3);
                taxOutput.TaxableBase = new AmountType();
                taxOutput.TaxableBase.TotalAmount = new DoubleTwoDecimalType((double)factura.Baseimp3);
                grossAmount += (double)factura.Baseimp3;
                taxOutput.TaxAmount = new AmountType();
                taxOutput.TaxAmount.TotalAmount = new DoubleTwoDecimalType((double)factura.Imporiv3);
                totalTaxOutputs += (double)factura.Imporiv3;
                inv.TaxesOutputs[2] = taxOutput;
            }
            catch (InvalidOperationException ioe)
            {
            }
            
            #endregion
            
            inv.InvoiceTotals = new InvoiceTotalsType();
            //-- Discounts for this invoice
            
            #region[Discounts]
            
            double totalGeneralDiscounts = 0.0;
            
            if (factura.Dtognral != (decimal)0.0)
            {
                inv.InvoiceTotals.GeneralDiscounts = new DiscountType[2];
                DiscountType discountType;
                
                discountType = new DiscountType();
                discountType.DiscountRate = new DoubleFourDecimalType((double)factura.Dtognral);
                discountType.DiscountAmount = new DoubleSixDecimalType((double)(factura.Impdtogr));
                discountType.DiscountReason = "Descuento general.";
                discountType.DiscountRateSpecified = true;
                inv.InvoiceTotals.GeneralDiscounts[0] = discountType;
                totalGeneralDiscounts += discountType.DiscountAmount;
                
                if (factura.Dtoppago != (decimal)0.0)
                {
                    discountType = new DiscountType();
                    discountType.DiscountRate = new DoubleFourDecimalType((double)factura.Dtoppago);
                    discountType.DiscountAmount = new DoubleSixDecimalType((double)(factura.Impdtopp));
                    discountType.DiscountReason = "Descuento pronto pago.";
                    discountType.DiscountRateSpecified = true;
                    inv.InvoiceTotals.GeneralDiscounts[1] = discountType;
                    totalGeneralDiscounts += discountType.DiscountAmount;
                }
            }
            
            #endregion
            
            ContaContext ctx2;
            
            //-- Totals for this invoice
            inv.InvoiceTotals.TotalGrossAmount = new DoubleTwoDecimalType((double)factura.Brutofac);
            inv.InvoiceTotals.TotalGeneralDiscounts = new DoubleTwoDecimalType(totalGeneralDiscounts);
            inv.InvoiceTotals.TotalGeneralDiscountsSpecified = true;
            inv.InvoiceTotals.TotalGeneralSurcharges = new DoubleTwoDecimalType(0.0);
            
            inv.InvoiceTotals.TotalGrossAmountBeforeTaxes = new DoubleTwoDecimalType((double)factura.Brutofac - totalGeneralDiscounts) + inv.InvoiceTotals.TotalGeneralSurcharges;
            inv.InvoiceTotals.TotalTaxOutputs = new DoubleTwoDecimalType(totalTaxOutputs);
            inv.InvoiceTotals.TotalTaxesWithheld = new DoubleTwoDecimalType(0);
            
            inv.InvoiceTotals.InvoiceTotal = new DoubleTwoDecimalType((double)factura.Totalfac);
            inv.InvoiceTotals.TotalOutstandingAmount = new DoubleTwoDecimalType((double)factura.Totalfac);
            inv.InvoiceTotals.TotalExecutableAmount = new DoubleTwoDecimalType((double)factura.Totalfac);
            
            //-- Invoice lines
            Spara1 param1 = ctx0.Spara1.FirstOrDefault<Spara1>();
            ctx2 = new ContaContext("contaEntity");
            
            i = 0;
            inv.Items = new InvoiceLineType[factura.Slifacs.Count]; // dimension = number of lines
            foreach (Slifac ln in factura.Slifacs)
            {
                inv.Items[i] = InvoiceLine(ln, ctx2, ctx0);
                i++;
            }
            fcte.Invoices[0] = inv;
            
            // Payments
            
            #region [Payments]
            
            // Obtener la fecha de pago
            if (numCuenta != "")
            {
                if (factura.Svencis.Count > 0)
                {
                    inv.PaymentDetails = new InstallmentType[factura.Svencis.Count];
                    int payNum = 0;
                    foreach (Svenci svenci in factura.Svencis)
                    {
                        DateTime fechaPago = svenci.Fecefect;
                        InstallmentType paymentDetail = new InstallmentType();
                        paymentDetail.InstallmentDueDate = fechaPago;
                        paymentDetail.InstallmentAmount = new DoubleTwoDecimalType((double)svenci.Impefect);
                        // Se asume en todos los casos que el pago se hace por cuenta bancaria
                        paymentDetail.PaymentMeans = PaymentMeansType.Item04;
                        paymentDetail.AccountToBeCredited = new AccountType();
                        paymentDetail.AccountToBeCredited.ItemElementName = ItemChoiceType.IBAN;
                        paymentDetail.AccountToBeCredited.Item = numCuenta;
                        inv.PaymentDetails[payNum] = paymentDetail;
                        payNum++;
                    }
                }
            }
        
            #endregion
        }
        
        public static decimal obtenerPorcentajeIva(ContaContext ctx2, byte codigIva)
        {
            return (from tipo in ctx2.Tiposivas
                    where tipo.Codigiva == codigIva
                    select tipo).FirstOrDefault<Tiposiva>().Porceiva;
        }
        
        #endregion
        
        #region ARIGASOL FACTURAE
        
        /// <summary>
        /// Generates an invoice from AriGasol application in Facturae format and returns it. 
        /// </summary>
        /// <param name="issuer">Invoice issuer</param>
        /// <param name="invoices">Invoice to be generated in facturae format</param>
        /// <returns>Invoice in facturae format</returns>
        public static Facturae GenerateAriGasolInvoice31(Sempre issuer, Schfac invoice, string numCuenta)
        {
            Facturae fcte = new Facturae();
            AriGasolFileHeader(fcte, issuer, invoice);
            AriGasolParties(fcte, issuer, invoice);
            AriGasolInvoices(fcte, invoice, numCuenta);
            return fcte;
        }
        
        private static void AriGasolFileHeader(Facturae fcte, Sempre issuer, Schfac invoice)
        {
            // File Header.
            fcte.FileHeader = new FileHeaderType();
            fcte.FileHeader.SchemaVersion = SchemaVersionType.Item32; // 3.1 Version
            fcte.FileHeader.Modality = ModalityType.I; // Individual
            fcte.FileHeader.InvoiceIssuerType = InvoiceIssuerTypeType.EM; // Issuer is "EMISOR"
            
            // Constructing batch identifier = Issuer nif + invoice serial + invoice number + invoice date
            //string batchIdentifier = String.Format("{0}{1}{2:0000000}{3:yyyMMdd}", 
            //                                        invoice.Ssocio.Nifsocio, 
            //                                        invoice.Letraser, 
            //                                        invoice.Numfactu, 
            //                                        invoice.Fecfactu);
            string batchIdentifier = String.Format("{0}{1:0000000}{2:yyyMMdd}",
                invoice.Letraser,
                invoice.Numfactu,
                invoice.Fecfactu);
            fcte.FileHeader.Batch = new BatchType();
            fcte.FileHeader.Batch.BatchIdentifier = batchIdentifier;
            fcte.FileHeader.Batch.InvoicesCount = 1; // Modality is individual 1 invoice per file
            
            // all amounts have the same value
            fcte.FileHeader.Batch.TotalInvoicesAmount = new AmountType();
            fcte.FileHeader.Batch.TotalInvoicesAmount.TotalAmount = new DoubleTwoDecimalType((double)invoice.Totalfac);
            fcte.FileHeader.Batch.TotalOutstandingAmount = new AmountType();
            fcte.FileHeader.Batch.TotalOutstandingAmount.TotalAmount = new DoubleTwoDecimalType((double)invoice.Totalfac);
            fcte.FileHeader.Batch.TotalExecutableAmount = new AmountType();
            fcte.FileHeader.Batch.TotalExecutableAmount.TotalAmount = new DoubleTwoDecimalType((double)invoice.Totalfac);
            fcte.FileHeader.Batch.InvoiceCurrencyCode = CurrencyCodeType.EUR; // invoices is in euros
        }
        
        private static void AriGasolParties(Facturae fcte, Sempre issuer, Schfac invoice)
        {
            // TODO: Person type code must be obtained from NIF
            fcte.Parties = new PartiesType();
            fcte.Parties.SellerParty = new BusinessType();
            fcte.Parties.SellerParty.TaxIdentification = new TaxIdentificationType();
            fcte.Parties.SellerParty.TaxIdentification.PersonTypeCode = PersonTypeCodeType.J;
            fcte.Parties.SellerParty.TaxIdentification.ResidenceTypeCode = ResidenceTypeCodeType.R;
            fcte.Parties.SellerParty.TaxIdentification.TaxIdentificationNumber = issuer.Nifempre;
            
            LegalEntityType legalEntity = new LegalEntityType();
            legalEntity.CorporateName = issuer.Nomempre;
            AddressType address = new AddressType();
            address.Address = issuer.Domempre;
            address.PostCode = issuer.Codposta;
            address.Town = issuer.Pobempre;
            address.Province = issuer.Proempre;
            address.CountryCode = CountryType.ESP;
            legalEntity.Item = address;
            
            fcte.Parties.SellerParty.Item = legalEntity;
            
            Ssocio buyer = invoice.Ssocio;
            fcte.Parties.BuyerParty = new BusinessType();
            fcte.Parties.BuyerParty.TaxIdentification = new TaxIdentificationType();
            fcte.Parties.BuyerParty.TaxIdentification.PersonTypeCode = PersonTypeCodeType.J;
            fcte.Parties.BuyerParty.TaxIdentification.ResidenceTypeCode = ResidenceTypeCodeType.R;
            fcte.Parties.BuyerParty.TaxIdentification.TaxIdentificationNumber = buyer.Nifsocio;
            
            // comprobacion de las unidades FACE
            // Hay que controlar en el caso de clientes de administración pública
            // montar la información de oficina contable, organo gestor y unidad tramitadora.
            // buscamos el cliente en FActuraE para ver si contiene las columnas
            FacturaEntity ctx4 = new FacturaEntity("FacturaEntity");
            Cliente cFacturae = (from c in ctx4.Clientes
                                 where c.CodclienArigasol == buyer.Codsocio
                                 select c).FirstOrDefault<Cliente>();
            if (cFacturae != null)
            {
                // Comprobamos que tiene los códigos para operar en Adm. Pública
                if (cFacturae.OrganoGestorCodigo != null && cFacturae.OrganoGestorCodigo != "")
                {
                    // Ahora hay que leer la unidad para conocer sus códigos
                    Unidad uAdm = (from u in ctx4.Unidads
                                   where u.OficinaContableCodigo == cFacturae.OficinaContableCodigo &&
                                         u.OrganoGestorCodigo == cFacturae.OrganoGestorCodigo &&
                                         u.UnidadTramitadoraCodigo == cFacturae.UnidadTramitadoraCodigo
                                   select u).FirstOrDefault<Unidad>();
                    // controlamos los descriptores 
                    string nomOrganoGestor = buyer.Nomsocio;
                    string codOrganoGestor = cFacturae.OficinaContableCodigo;
                    string nomUnidadTramitadora = buyer.Nomsocio;
                    string codUnidadTramitadora = cFacturae.UnidadTramitadoraCodigo;
                    string nomOficinaContable = buyer.Nomsocio;
                    string codOficinaContable = cFacturae.OficinaContableCodigo;
                    if (uAdm != null)
                    {
                        nomOrganoGestor = uAdm.OrganoGestorNombre;
                        codOrganoGestor = uAdm.OrganoGestorCodigo;
                        nomUnidadTramitadora = uAdm.UnidadTramitadoraNombre;
                        codUnidadTramitadora = uAdm.UnidadTramitadoraCodigo;
                        nomOficinaContable = uAdm.OficinaContableNombre;
                        codOficinaContable = uAdm.OficinaContableCodigo;
                    }
                    
                    // De momento montamos todas las direcciones como comunes
                    address = new AddressType();
                    address.Address = buyer.Domsocio;
                    address.PostCode = buyer.Codposta;
                    address.Town = buyer.Pobsocio;
                    address.Province = buyer.Prosocio;
                    address.CountryCode = CountryType.ESP;
                    // Ahora montamos las diferentes unidades administrativas (3)
                    fcte.Parties.BuyerParty.AdministrativeCentres = new AdministrativeCentreType[3];
                    AdministrativeCentreType admCenter = new AdministrativeCentreType();
                    // Organo gestor
                    admCenter.CentreCode = codOrganoGestor;
                    admCenter.RoleTypeCode = RoleTypeCodeType.Item02;
                    admCenter.RoleTypeCodeSpecified = true;
                    admCenter.Item = address;
                    admCenter.CentreDescription = nomOrganoGestor;
                    fcte.Parties.BuyerParty.AdministrativeCentres[0] = admCenter;
                    // Unidad tramitadora
                    admCenter = new AdministrativeCentreType();
                    admCenter.CentreCode = codUnidadTramitadora;
                    admCenter.RoleTypeCode = RoleTypeCodeType.Item03;
                    admCenter.RoleTypeCodeSpecified = true;
                    admCenter.Item = address;
                    admCenter.CentreDescription = nomUnidadTramitadora;
                    fcte.Parties.BuyerParty.AdministrativeCentres[1] = admCenter;
                    // oficina contable
                    admCenter = new AdministrativeCentreType();
                    admCenter.CentreCode = codOficinaContable;
                    admCenter.RoleTypeCode = RoleTypeCodeType.Item01;
                    admCenter.RoleTypeCodeSpecified = true;
                    admCenter.Item = address;
                    admCenter.CentreDescription = nomOficinaContable;
                    fcte.Parties.BuyerParty.AdministrativeCentres[2] = admCenter;
                }
            }
            
            legalEntity = new LegalEntityType();
            legalEntity.CorporateName = buyer.Nomsocio;
            address = new AddressType();
            address.Address = buyer.Domsocio;
            address.PostCode = buyer.Codposta;
            address.Town = buyer.Pobsocio;
            address.Province = buyer.Prosocio;
            address.CountryCode = CountryType.ESP;
            legalEntity.Item = address;
        
            fcte.Parties.BuyerParty.Item = legalEntity;
        }
        
        private static void AriGasolInvoices(Facturae fcte, Schfac invoice, string numCuenta)
        {
            fcte.Invoices = new InvoiceType[1]; // One invoice only
            InvoiceType inv = new InvoiceType();
            inv.InvoiceHeader = new InvoiceHeaderType();
            inv.InvoiceHeader.InvoiceNumber = invoice.Numfactu.ToString();
            inv.InvoiceHeader.InvoiceSeriesCode = invoice.Letraser.ToString();
            inv.InvoiceHeader.InvoiceClass = InvoiceClassType.OO; // TODO: We are fixing invoice class value (perhaps incorrect)
            
            inv.InvoiceIssueData = new InvoiceIssueDataType();
            inv.InvoiceIssueData.IssueDate = invoice.Fecfactu;
            inv.InvoiceIssueData.InvoiceCurrencyCode = CurrencyCodeType.EUR; // fixed euros
            inv.InvoiceIssueData.TaxCurrencyCode = CurrencyCodeType.EUR; // taxes in euros too.
            inv.InvoiceIssueData.LanguageName = LanguageCodeType.es; // always in Spanish
            
            inv.TaxesOutputs = new TaxOutputType[NumberOfTaxes(invoice)];
            int i = 0; // index of TaxesOutputs (begins cero)
            double grossAmount = 0;
            double totalTaxOutputs = 0;
            TaxOutputType taxOutput; // each tax output
            // AtiGasol invoice could have 3 diferent fixed taxes
            if (invoice.Baseimp1 != 0 && invoice.Baseimp1 != null)
            {
                taxOutput = new TaxOutputType();
                taxOutput.TaxTypeCode = TaxTypeCodeType.Item01;
                taxOutput.TaxRate = new DoubleTwoDecimalType((double)invoice.Porciva1);
                taxOutput.TaxableBase = new AmountType();
                taxOutput.TaxableBase.TotalAmount = new DoubleTwoDecimalType((double)invoice.Baseimp1);
                grossAmount += (double)invoice.Baseimp1;
                taxOutput.TaxAmount = new AmountType();
                taxOutput.TaxAmount.TotalAmount = new DoubleTwoDecimalType((double)invoice.Impoiva1);
                totalTaxOutputs += (double)invoice.Impoiva1;
                inv.TaxesOutputs[i] = taxOutput;
                i++;
            }
            if (invoice.Baseimp2 != 0 && invoice.Baseimp2 != null)
            {
                taxOutput = new TaxOutputType();
                taxOutput.TaxTypeCode = TaxTypeCodeType.Item01;
                taxOutput.TaxRate = new DoubleTwoDecimalType((double)invoice.Porciva2);
                taxOutput.TaxableBase = new AmountType();
                taxOutput.TaxableBase.TotalAmount = new DoubleTwoDecimalType((double)invoice.Baseimp2);
                grossAmount += (double)invoice.Baseimp2;
                taxOutput.TaxAmount = new AmountType();
                taxOutput.TaxAmount.TotalAmount = new DoubleTwoDecimalType((double)invoice.Impoiva2);
                totalTaxOutputs += (double)invoice.Impoiva2;
                inv.TaxesOutputs[i] = taxOutput;
                i++;
            }
            if (invoice.Baseimp3 != 0 && invoice.Baseimp3 != null)
            {
                taxOutput = new TaxOutputType();
                taxOutput.TaxTypeCode = TaxTypeCodeType.Item01;
                taxOutput.TaxRate = new DoubleTwoDecimalType((double)invoice.Porciva3);
                taxOutput.TaxableBase = new AmountType();
                taxOutput.TaxableBase.TotalAmount = new DoubleTwoDecimalType((double)invoice.Baseimp3);
                grossAmount += (double)invoice.Baseimp3;
                taxOutput.TaxAmount = new AmountType();
                taxOutput.TaxAmount.TotalAmount = new DoubleTwoDecimalType((double)invoice.Impoiva3);
                totalTaxOutputs += (double)invoice.Impoiva3;
                inv.TaxesOutputs[i] = taxOutput;
                i++;
            }
            //-- Totals for this invoice
            inv.InvoiceTotals = new InvoiceTotalsType();
            inv.InvoiceTotals.TotalGrossAmount = new DoubleTwoDecimalType(grossAmount);
            inv.InvoiceTotals.TotalGeneralDiscounts = new DoubleTwoDecimalType(0);
            inv.InvoiceTotals.TotalGeneralSurcharges = new DoubleTwoDecimalType(0);
            inv.InvoiceTotals.TotalGrossAmountBeforeTaxes = new DoubleTwoDecimalType(grossAmount);
            inv.InvoiceTotals.TotalTaxOutputs = new DoubleTwoDecimalType(totalTaxOutputs);
            inv.InvoiceTotals.TotalTaxesWithheld = new DoubleTwoDecimalType(0);
            inv.InvoiceTotals.InvoiceTotal = new DoubleTwoDecimalType((double)invoice.Totalfac);
            inv.InvoiceTotals.TotalOutstandingAmount = new DoubleTwoDecimalType((double)invoice.Totalfac);
            inv.InvoiceTotals.TotalExecutableAmount = new DoubleTwoDecimalType((double)invoice.Totalfac);
            //-- Invoice lines
            i = 0;
            inv.Items = new InvoiceLineType[invoice.Slhfacs.Count]; // dimension = number of lines
            foreach (Slhfac ln in invoice.Slhfacs)
            {
                inv.Items[i] = AriGasolInvoiceLine(ln);
                i++;
            }
            fcte.Invoices[0] = inv;

            #region [Payments]
            
            // Obtener la fecha de pago
            if (numCuenta != "")
            {
                //if (factura.Svencis.Count > 0)
                //{
                //    inv.PaymentDetails = new InstallmentType[factura.Svencis.Count];
                //    int payNum = 0;
                //    foreach (Svenci svenci in factura.Svencis)
                //    {
                //        DateTime fechaPago = svenci.Fecefect;
                //        InstallmentType paymentDetail = new InstallmentType();
                //        paymentDetail.InstallmentDueDate = fechaPago;
                //        paymentDetail.InstallmentAmount = new DoubleTwoDecimalType((double)svenci.Impefect);
                //        // Se asume en todos los casos que el pago se hace por cuenta bancaria
                //        paymentDetail.PaymentMeans = PaymentMeansType.Item04;
                //        paymentDetail.AccountToBeCredited = new AccountType();
                //        paymentDetail.AccountToBeCredited.ItemElementName = ItemChoiceType.IBAN;
                //        paymentDetail.AccountToBeCredited.Item = numCuenta;
                //        inv.PaymentDetails[payNum] = paymentDetail;
                //        payNum++;
                //    }
                //}
            }

            #endregion
        }
            
        private static int NumberOfTaxes(Schfac invoice)
        {
            int i = 0;
            if (invoice.Baseimp1 != 0)
                i++;
            if (invoice.Baseimp2 != 0)
                i++;
            if (invoice.Baseimp3 != 0)
                i++;
            return i;
        }
            
        private static InvoiceLineType AriGasolInvoiceLine(Slhfac line)
        {
            InvoiceLineType il = new InvoiceLineType();
            il.ItemDescription = line.Sartic.Nomartic;
            il.Quantity = (double)line.Cantidad;
            il.UnitOfMeasure = UnitOfMeasureType.Item01; // TODO: Change for de correct unit type.
            double grossAmount = (double)line.Implinea / (1.0 + (OldIvaType2((int)line.Sartic.Codigiva) / 100.0));
            if (grossAmount == null)
                grossAmount = 0;
            double unitPrice = 0;
            if (line.Cantidad != 0)
                unitPrice = grossAmount / (double)line.Cantidad;
            
            //--
            //grossAmount = unitPrice * (double)line.Cantidad;
            if (line.Numfactu == 2687075)
            {
            }
            double taxAmount = (double)line.Implinea - grossAmount;
            if (unitPrice == null)
                unitPrice = 0;
            il.UnitPriceWithoutTax = new DoubleSixDecimalType(unitPrice);
            unitPrice = Double.Parse(String.Format("{0:0.000000}", unitPrice));
            grossAmount = unitPrice * (double)line.Cantidad;
            il.TotalCost = new DoubleSixDecimalType(grossAmount);
            il.GrossAmount = new DoubleSixDecimalType(grossAmount);
            il.TaxesOutputs = new InvoiceLineTypeTax[1]; // only one tax per line
            InvoiceLineTypeTax lTax = new InvoiceLineTypeTax();
            lTax.TaxTypeCode = TaxTypeCodeType.Item01; // always VAT
            lTax.TaxRate = new DoubleTwoDecimalType(OldIvaType2((int)line.Sartic.Codigiva));
            lTax.TaxableBase = new AmountType();
            lTax.TaxableBase.TotalAmount = new DoubleTwoDecimalType(grossAmount);
            lTax.TaxAmount = new AmountType();
            lTax.TaxAmount.TotalAmount = new DoubleTwoDecimalType(taxAmount);
            il.TaxesOutputs[0] = lTax;
            return il;
        }
            
        private static double OldIvaType2(int ty)
        {
            double i;
            switch (ty.ToString())
            {
                // Noviembre 2013
                // Estaba el 18. Cambiamos el 1 y el 2 a 21 y 10.  Añadimos el 21 22 que seran 18 y 8
                case "1":
                    i = 21.0; //                    i = 18.0;
                    break;
                case "2":
                    i = 10.0; //                    i = 8.0;
                    break;
                case "3":
                    i = 4.0;
                    break;
                case "4":
                    i = 0.0;
                    break;
                case "8":
                    i = 16.0;
                    break;
                case "9":
                    i = 7.0;
                    break;
                case "21":
                    i = 18.0;
                    break;
                case "22":
                    i = 8.0;
                    break;
                default:
                    i = 21.0; //                    i = 18.0;
                    break;
            }
            return i;
        }

        #endregion
    }
}