using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDAVSharp.Server.Stores
{
    /// <summary>
    /// This interface add more capabilities to the original <see cref="IWebDavStoreCollection" />
    /// and it was introduced not to break the original code, but to allow faster retrieval for 
    /// child items.
    /// </summary>
    public interface IWebDavStoreCollectionExtended : IWebDavStoreCollection
    {
        /// <summary>
        /// Retrieve the <see cref="IWebDavStoreItem" /> given the full path of the 
        /// request. This is necessary to limit the number of calls needed to retrieve
        /// an element when we have deeper hierarchies 
        /// </summary>
        /// <param name="fullPath">This is the full path of the children we want to retrieve. 
        /// This imply that the real full path of the element is the full path of the current
        /// element plus this value. Ex, if we have path a/b/c/d and only node b is a 
        /// <see cref="IWebDavStoreCollectionExtended"/> the full path value is "c/d". </param>
        /// <returns>The <see cref="IWebDavStoreItem"/> of the given path. If this component
        /// returns null it means that the component is not found on the given path.</returns>
        IWebDavStoreItem GetItemByFullPath(String fullPath);

        /// <summary>
        /// Returns true if this component can resolve that specific fullPath. It is necessary
        /// because we could have some part of virtual WebDavFile system that are not able to 
        /// resolve all path with Full Path.
        /// </summary>
        /// <param name="fullPath"></param>
        /// <returns></returns>
        Boolean CanResolveFullPath(String fullPath);
    }
}
